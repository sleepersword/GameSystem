using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using SCL.IO;

namespace IndexedByteFormatInterface
{
    internal class DocumentWriter : IDisposable
    {
        public Document ActiveDocument { get; private set; }
        private FileStream docFs { get { return ActiveDocument.DataStream; } }
        private FileInfo tempFile;

        public DocumentWriter(Document doc)
        {
            ActiveDocument = doc;
            tempFile = new FileInfo(Path.GetTempFileName());
        }

        public void AddElements(params IElement[] elements)
        {
            AddItems(elements);
        }

        private void AddItems(params IElement[] items)
        {
            Identificator[] ids = new Identificator[items.Length];
            uint currentPos = ActiveDocument.Head.BeginOfData + ActiveDocument.Head.LengthOfData;

            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                ids[i] =
                    new Identificator(item.ID, FlagManager.GetIndexByExtension(item.Extension), currentPos,
                        (uint)item.LengthInBytes);
                currentPos += (uint)item.LengthInBytes;
            }
            AddItemsToData(items);

            ActiveDocument.Head.AddItems(ids);
            ActiveDocument.Head.SetMd5Hash(Data.Calculate_MD5(tempFile.FullName));

            RecreateDocument();
        }

        private void AddItemsToData(IElement[] sources)
        {
            using (FileStream tempFs = tempFile.OpenWrite())
            {
                docFs.Position = ActiveDocument.Head.BeginOfData;
                for (uint i = 0; i < ActiveDocument.Head.LengthOfData; i++)
                {
                    tempFs.WriteByte((byte)docFs.ReadByte());
                }

                foreach (var sourceStream in sources.Select(source => source.GetSourceStream()))
                {
                    for (uint i = 0; i < sourceStream.Length; i++)
                    {
                        tempFs.WriteByte((byte)sourceStream.ReadByte());
                    }
                    sourceStream.Dispose();
                }
            }
        }

        private void RecreateDocument()
        {
            docFs.Position = 0;
            docFs.SetLength(ActiveDocument.Head.LengthOfData + ActiveDocument.Head.ElementCount * Identificator.SIZE_IN_BYTES + Header.FIXED_SIZE_IN_BYTES);

            ActiveDocument.Head.ToStream(ActiveDocument.DataStream);

            using (FileStream tempFs = tempFile.OpenRead())
            {
                for (uint i = 0; i < tempFs.Length; i++)
                {
                    docFs.WriteByte((byte)tempFs.ReadByte());
                }
            }
            tempFile.Delete();
        }

        public void Dispose()
        {
            if (tempFile != null && tempFile.Exists)
            {
                tempFile.Delete();
            }
            if (ActiveDocument != null)
            {
                ActiveDocument.Dispose();
                ActiveDocument = null;
            }
        }
    }
}
