using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCL.IO;

namespace IndexedByteFormatInterface
{

    /// <summary>
	/// Represents an IBF document in memory.
	/// </summary>
    public class Document : IEnumerable<UInt16>, IDisposable
    {
    	#region Constant Fields
    	
        public const UInt32 MAX_FILESIZE = UInt32.MaxValue;
        public const byte IBF_VERSION = 0x3;
        
        #endregion

        #region Public Fields & Properties
        
        /// <summary>
        /// Returns the Name of the document. It is the same like filename without extension.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Returns the absolute path of the document.
        /// </summary>
        public string FilePath { get { return Path.GetFullPath(Name + ".ibf"); } }
        /// <summary>
        /// Returns the amount of elements in the document.
        /// </summary>
        public int ElementCount { get { return Head.ElementCount; } }
		/// <summary>
        /// Returns the MD5 Hash of the data stream.
        /// </summary>        
        public byte[] MD5Hash { get { return Head.MD5Checksum; } }
        /// <summary>
        /// >Returns an iterable list of the elements in the document.
        /// </summary>
        public IEnumerable<UInt16> ElementIndices { get { return Head.Indices.Keys.ToArray(); } }
        
        #endregion

        private FileStream _dataStream;
        internal FileStream DataStream
        {
            get
            {
                return _dataStream; 
            }
            set
            {
                if (_dataStream != null)
                {
                    _dataStream.Dispose();
                }

                if (value == null || value.CanRead && value.CanWrite && value.CanSeek)
                {
                    _dataStream = value;
                }
                else
                {
                    throw new Exception("The filestream has to support reading & writing.");
                }
            }
        }
        internal Header Head { get; private set; }
        
        internal Document(string name, Header head, FileStream fs)
        {
            Name = name;
            Head = head;
            DataStream = fs;
        }

        // ReSharper disable once InconsistentNaming
        public bool CheckMD5Hash()
        {
            return Head.LengthOfData > int.MaxValue ? CheckMd5_LargeFile() : CheckMd5();
        }

        private bool CheckMd5()
        {
            bool result = false;
            using (MemoryStream ms = new MemoryStream((int)Head.LengthOfData))
            {
                foreach (UInt16 index in this.ElementIndices)
                {
                    var tempStream = ReadElement(index);
                    ms.Write(tempStream.ToArray(), 0, (int)tempStream.Length);
                    tempStream.Dispose();
                }
                ms.Position = 0;

                byte[] calcMD5 = Data.Calculate_MD5(ms);
                if (Data.CompareByteArray(calcMD5, MD5Hash))
                {
                    result = true;
                }
            }

            return result;
        }
        private bool CheckMd5_LargeFile()
        {
            bool result = false;
            using (FileStream fs = new FileStream("md5.chck", FileMode.CreateNew, FileAccess.Write))
            {
                foreach (UInt16 index in this.ElementIndices)
                {
                    var tempStream = ReadElement(index);
                    fs.Write(tempStream.ToArray(), 0, (int)tempStream.Length);
                    tempStream.Dispose();
                }
            }

            byte[] calcMD5 = Data.Calculate_MD5("md5.chck");
            if (Data.CompareByteArray(calcMD5, MD5Hash))
                {
                    result = true;
                }
            File.Delete("md5.chck");

            return result;
        }

        public byte[] GetElementByID_RawBytes(UInt16 id)
        {
            if (!Head.Indices.ContainsKey(id))
            {
                throw new IndexOutOfRangeException("There is no element with ID:" + id);
            }

            var element = ReadElement(id);
            byte[] data = element.ToArray();
            element.Dispose();

            return data;
        }

        public MemoryStream GetElementByID(UInt16 id)
        {
            if (!Head.Indices.ContainsKey(id))
            {
                throw new IndexOutOfRangeException("There is no element with ID:" + id);
            }

            var element = ReadElement(id);

            return element;
        }

        private MemoryStream ReadElement(UInt16 id)
        {
            var index = Head.Indices[id];
            _dataStream.Position = index.FirstByte;
            MemoryStream ms = new MemoryStream((int)index.Length);

            for (uint i = 0; i < index.Length; i++)
            {
                ms.WriteByte((byte)_dataStream.ReadByte());
            }

            return ms;
        }

        public static Document ReadDocument(string filePath)
        {
            string name = Path.GetFileNameWithoutExtension(filePath);
            Header head;
            FileStream fs = File.OpenRead(filePath);
            
//            using (BinaryReader br = new BinaryReader(fs, Encoding.ASCII, true))
//            {
//                head = Header.FromStream(br);
//            }
			using (BinaryReader br = new BinaryReader(fs, Encoding.ASCII))
            {
                head = Header.FromStream(br);
            }
			
            return new Document(name, head, File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
        }

        public string GetExtension(UInt16 index)
        {
            UInt16 e = Head.Indices[index].Extension;
            return '.' + FlagManager.GetExtensionByIndex(e);
        }    
        
        /// <summary>
        /// Provides methods to create a new IBF document.
        /// </summary>
        public static class Factory 
        {
        	public static Document FromFiles(string documentName, params FileIndex[] files)
        	{
            	Array.Sort(files);
            	Header head = ComputeHead(files);
            	FileInfo tempFile = new FileInfo(WriteFilesToTemp(documentName, files));
            	byte[] md5Bytes = Data.Calculate_MD5(tempFile.FullName);
           		head.SetMd5Hash(md5Bytes);

            	MergeHeadTemp(documentName, head, tempFile);
        	    var fs = File.Open(documentName + ".ibf", FileMode.Open, FileAccess.ReadWrite);

            	return new Document(documentName, head, fs);
        	}

        	private static void MergeHeadTemp(string documentName, Header head, FileInfo temp)
        	{
            	FileStream fs = new FileStream(documentName + ".ibf", FileMode.Create, FileAccess.Write, FileShare.Write);
                head.ToStream(fs);
            
            	using (FileStream tempStream = temp.OpenRead())
            	{
                	for (int i = 0; i < temp.Length; i++)
                	{
                    	fs.WriteByte((byte)tempStream.ReadByte());
                	}
            	}

            	temp.Delete();

        	    fs.Dispose();
        	}

        	private static Header ComputeHead(FileIndex[] files)
        	{
            	int fileCount = files.Length;
            	UInt16 beginofData = (UInt16)(Header.FIXED_SIZE_IN_BYTES + Identificator.SIZE_IN_BYTES * fileCount);
            	uint currentPosition = beginofData;
            	Identificator[] indices = new Identificator[fileCount];

            	for (int i = 0; i < files.Length; i++)
            	{
                	FileIndex element = files[i];
                	UInt32 elementSize = (UInt32) element.File.Length;
                	string ext = element.File.Extension.Remove(0, 1);
                	UInt16 extIndex = FlagManager.GetIndexByExtension(ext);
                	indices[i] = new Identificator(element.ID, extIndex, currentPosition, elementSize);
                	currentPosition += elementSize;
            	}

            	return new Header
            	(
                	IBF_VERSION,
                	beginofData,
                	(UInt16)(currentPosition - beginofData),
                	(UInt16)fileCount,
                	new byte[6], 
                	indices
            	);
        	}

        	private static string WriteFilesToTemp(string docName, IEnumerable<FileIndex> files)
        	{
            	string tempPath = Path.GetTempPath() + docName + ".ibft_";
            	using (FileStream fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            	{
                	foreach (FileIndex fi in files)
                	{
                    	using (FileStream tStream = File.OpenRead(fi.File.FullName))
                    	{
                        	for (int i = 0; i < fi.File.Length; i++)
                        	{
                            	fs.WriteByte((byte)tStream.ReadByte());
                        	}
                    	}
                	}
            	}

            return tempPath;
        	}
        
        }

        #region Interface implementation

        public void Dispose()
        {
            if (DataStream != null)
            {
                DataStream.Dispose();
                DataStream = null;
            }

            Head = null;
        }

        public MemoryStream this[UInt16 id]
        {
            get { return GetElementByID(id); }
        }

        public IEnumerator<ushort> GetEnumerator()
        {
            return ((IEnumerable<ushort>) Head.Indices.Keys).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        } 
        #endregion
    }

    public struct FileIndex : IComparable<FileIndex>, IElement
    {
        private FileInfo _file;
        private UInt16 _id;
        public FileInfo File { get { return _file; }}
        public UInt16 ID { get { return _id; } }
        public string Extension { get { return File.Extension; } }
        public long LengthInBytes { get { return _file.Length; } }

        public Stream GetSourceStream()
        {
            return File.OpenRead();
        }

        public FileIndex(string filePath, UInt16 id)
        {
            _file = new FileInfo(filePath);
            _id = id;
        }

        public int CompareTo(FileIndex other)
        {
            return this.ID.CompareTo(other.ID);
        }
    }
}