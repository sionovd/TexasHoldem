using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserModule
{
    class UserHash
    {
        
        public string GetHashed(string username, string passStr)
        {
            if (passStr == null) return null;

            byte[] hashed = GenerateSaltedHash(Encoding.ASCII.GetBytes(passStr), Encoding.ASCII.GetBytes(username));
            return System.Convert.ToBase64String(hashed);
        }
        private byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
                new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }
}
