using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SCL.IO
{
    public static class Data
    {

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int memcmp(byte[] b1, byte[] b2, long count);

        public static bool CompareByteArray(byte[] b1, byte[] b2)
        {
            // Validate buffers are the same length.
            // This also ensures that the count does not exceed the length of either buffer.  
            return b1.Length == b2.Length && memcmp(b1, b2, b1.Length) == 0;
        }


        public static byte[] Calculate_MD5(string filePath)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(filePath);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] md5Hash = md5.ComputeHash(fs);
            fs.Dispose();

            return md5Hash;
        }

        public static byte[] Calculate_MD5(MemoryStream stream)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] md5Hash = md5.ComputeHash(stream);

            return md5Hash;
        }
    }
}
