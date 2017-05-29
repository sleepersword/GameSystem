using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IndexedByteFormatInterface
{
    /// <summary>
    /// Holds information about the IBF document.
    /// </summary>
    internal class Header                 //31 + sizeof(Indices)
    {
        public const int FIXED_SIZE_IN_BYTES = 31;

        private byte _version;
        private byte[] _flags;
        private byte[] _md5Hash;

        public byte Version
        {
            get { return _version; }
            private set
            {
                if (value != Document.IBF_VERSION) throw new Exception("The file has the the wrong version. Supported is only v" + Document.IBF_VERSION);
                _version = value;
            }
        }                               //1
        public byte[] MD5Checksum
        {
            get { return _md5Hash; }
            private set
            {
                if (value.Length != 16)
                {
                    throw new ArgumentException("The given parameter isn't a MD5 hash.", "value");
                }
                _md5Hash = value;
            }
        }                         //16
        public UInt16 BeginOfData { get; private set; }      //2
        public UInt32 LengthOfData { get; private set; }     //4
        public UInt16 ElementCount { get; private set; }     //2
        public byte[] Flags
        {
            get
            {
                return _flags;
            }
            private set
            {
                if (value.Length != 6)
                {
                    throw new ArgumentException("The given parameter isn't avalid IBF flag container.", "value");
                }
                _flags = value;
            }
        }                               //6
        public Dictionary<UInt16, Identificator> Indices { get; private set; } //10*ElementCount

        public Header(byte version, UInt16 beginofData, UInt32 lengthofData, UInt16 elementCount, byte[] flags,
            IEnumerable<Identificator> indices)
        {
            Version = version;
            BeginOfData = beginofData;
            LengthOfData = lengthofData;
            ElementCount = elementCount;
            Flags = flags;
            Indices = new Dictionary<ushort, Identificator>(ElementCount);

            foreach (var id in indices)
            {
                Indices.Add(id.ID, id);
            }
        }
        public Header(byte version, byte[] md5, UInt16 beginofData, UInt32 lengthofData, UInt16 elementCount, byte[] flags,
            IEnumerable<Identificator> indices) : this(version, beginofData, lengthofData, elementCount, flags, indices)
        {
            MD5Checksum = md5;
        }

        internal void SetMd5Hash(byte[] hash)
        {
            MD5Checksum = hash;
        }

        internal void AddItems(params Identificator[] items)
        {
            MD5Checksum = new byte[16];
            foreach (var item in items)
            {
                Indices.Add(item.ID, item);
                LengthOfData += item.Length;
            }
            ElementCount += 1;
            BeginOfData += (ushort)(Identificator.SIZE_IN_BYTES * items.Length);
        }

        public void ToStream(Stream stream)
        {
            BinaryWriter bw = new BinaryWriter(stream);
            bw.Write(Version);
            bw.Write(MD5Checksum, 0, 16);
            bw.Write(BeginOfData);
            bw.Write(LengthOfData);
            bw.Write(ElementCount);
            bw.Write(Flags, 0, 6);
            bw.Flush();

            foreach (var index in Indices.Values)
            {
                index.ToStream(bw);
            }
            bw.Flush();
        }

        public static Header FromStream(BinaryReader br)
        {
            byte version = br.ReadByte();
            byte[] md5Bytes = br.ReadBytes(16);
            UInt16 beginofData = br.ReadUInt16();
            UInt32 lengthofData = br.ReadUInt32();
            UInt16 elementCount = br.ReadUInt16();
            byte[] flags = br.ReadBytes(6);
            Identificator[] indices = new Identificator[elementCount];

            for (int i = 0; i < elementCount; i++)
            {
                indices[i] = Identificator.FromStream(br);
            }

            return new Header
            (
                version,
                md5Bytes,
                beginofData,
                lengthofData,
                elementCount,
                flags,
                indices
            );
        }
    }
}
