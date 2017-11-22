using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace UserSystem
{
    public static class Hash
    {
        public static String Data(String InputData, MD5 Hash)
        {
            return GetMD5Hash(Hash, InputData);
        }

        public static bool Verify(String InputData, String HashValue, MD5 Hash)
        {
            String InputHash = GetMD5Hash(Hash, InputData);
            StringComparer Comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == Comparer.Compare(InputHash, HashValue)) return true;
            else return false;
        }

        private static String GetMD5Hash(MD5 Hash, String InputData)
        {
            byte[] ByteData = Hash.ComputeHash(Encoding.UTF8.GetBytes(InputData));
            StringBuilder StringBuilder = new StringBuilder();
            for (int i = 0; i < ByteData.Length; i++)
                StringBuilder.Append(ByteData[i].ToString("x2"));
            return StringBuilder.ToString();
        }
    }
}
