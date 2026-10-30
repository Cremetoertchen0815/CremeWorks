using System;
using System.Security.Cryptography;
using System.Text;

namespace CremeWorks.App.Networking.Cloud
{
    public class StringHasher
    {
        public static string GetConsistentHash(string input)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
