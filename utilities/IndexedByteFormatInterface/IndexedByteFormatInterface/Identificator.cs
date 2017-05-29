using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexedByteFormatInterface
{
    internal struct Identificator  //12
    {
        public const int SIZE_IN_BYTES = 12;

        public UInt16 ID;        //2
        public UInt16 Extension; //2
        public UInt32 FirstByte; //4
        public UInt32 Length;    //4

        public Identificator(UInt16 id, UInt16 ext, UInt32 first, UInt32 length)
        {
            ID = id;
            Extension = ext;
            FirstByte = first;
            Length = length;
        }

        public void ToStream(BinaryWriter bw)
        {
            bw.Write(ID);
            bw.Write(Extension);
            bw.Write(FirstByte);
            bw.Write(Length);
        }
        public static Identificator FromStream(BinaryReader br)
        {
            UInt16 id = br.ReadUInt16();
            UInt16 ext = br.ReadUInt16();
            UInt32 first = br.ReadUInt32();
            UInt32 length = br.ReadUInt32();

            return new Identificator(id,ext, first, length);
        }
    }
}
