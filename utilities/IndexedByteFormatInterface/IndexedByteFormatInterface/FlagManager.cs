using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexedByteFormatInterface
{
    internal static class FlagManager
    {

        static FlagManager()
        {
            _extToUShortDic = new Dictionary<string, ushort>(COUNT_OF_EXTENSIONS);
            _ushortToExtDic = new Dictionary<ushort, string>(COUNT_OF_EXTENSIONS);

            using (StreamReader sr = new StreamReader(File.OpenRead("flag_extensions.cfg")))
            {
                for (int i = 0; i < COUNT_OF_EXTENSIONS; i++)
                {
                    string ext = sr.ReadLine();
                    _extToUShortDic.Add(ext, (UInt16)i);
                    _ushortToExtDic.Add((UInt16)i, ext);
                }
            }

        }

        #region 0x1::Extension
        
        private static Dictionary<string, UInt16> _extToUShortDic;
        private static Dictionary<UInt16, string> _ushortToExtDic;
        private const int COUNT_OF_EXTENSIONS = 6962;
        
        public static string GetExtensionByIndex(UInt16 index)
        {
            return _ushortToExtDic[index];
        }

        public static UInt16 GetIndexByExtension(string ext)
        {
            if (ext[0] == '.') ext = ext.Remove(0, 1);
            return _extToUShortDic[ext];
        }
        
        #endregion
    }
}
