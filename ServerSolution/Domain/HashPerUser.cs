using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Domain.UserModule;

namespace Domain
{
    class HashPerUser
    {
        private User user;

        public HashPerUser(User user)
        {
            this.user = user;
        }
        public string GetHashed()
        {
            if (user == null) return null;
            string passStr = user.GetPassword();
            if(passStr == null) return null;

            byte[] hashed = GenerateSaltedHash(Encoding.ASCII.GetBytes(passStr), Encoding.ASCII.GetBytes(user.Username));
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
