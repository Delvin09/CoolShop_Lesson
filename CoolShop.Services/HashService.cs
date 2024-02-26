using CoolShop.Common.Services;
using System.Security.Cryptography;
using System.Text;

namespace CoolShop.Services
{
    internal class HashService : IHashService
    {
        public (byte[] hash, byte[] salt) GetHash(string value, byte[]? salt = null)
        {
            var hmac = salt != null ? new HMACSHA512(salt) : new HMACSHA512();
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(value));

            return (hash, hmac.Key);
        }
    }
}
