using System;
using System.Security.Cryptography;

namespace Hated.Infrastructure.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly int DeriveBytesIterationsCount = 10000;
        private static readonly int SaltSize = 40;

        public string GetSalt(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("Value to generate salt is empty or null");
            }
            
            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("Value to get hash is empty or null");
            }
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new Exception("Salt to get hash is empty or null");
            }

            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}