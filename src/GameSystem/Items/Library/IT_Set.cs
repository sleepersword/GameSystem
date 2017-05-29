using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProtoBuf;

namespace GameSystem.Items
{
    [ProtoContract]
    public class IT_Set
    {
        [ProtoMember(1)]
        public int Count;
        [ProtoMember(2)]
        public IT_Item[] Items;
        [ProtoMember(3)]
        public string Name;

        public IT_Set(string name, params IT_Item[] items)
        {
            Name = name;
            Items = items;
            Count = Items.Length;
        }

        private IT_Set()
        {
            Items = new GameSystem.Items.IT_Item[0];
            Name = "";
            Count = 0;
        }

        public static FileInfo SerializeSetToFile(string fileName, IT_Set set)
        {
            FileInfo file = new FileInfo(fileName);

            FileStream fs;
            if (file.Exists)
            {
                fs = file.Open(FileMode.Truncate, FileAccess.Write, FileShare.Write);
            }
            else
            {
                fs = file.Create();
            }

            if (!fs.CanWrite)
            {
                fs.Dispose();
                file.Delete();
                return null;
            }

            Serializer.Serialize(fs, set);

            fs.Dispose();
            return file;
        }

        public static IT_Set DeserializeSetFromFile(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            FileStream fs;
            if (file.Exists)
            {
                fs = file.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            else
            {
                return null;
            }

            if (!fs.CanRead)
            {
                fs.Dispose();
                file.Delete();
                return null;
            }

            IT_Set set = Serializer.Deserialize<IT_Set>(fs);

            fs.Dispose();
            return set;
        }
    }
}
