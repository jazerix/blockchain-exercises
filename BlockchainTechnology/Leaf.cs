using System;
using System.Security.Cryptography;
using System.Text;

namespace BlockchainTechnology
{
    public class Leaf
    {
        public string Data { get; set; }

        public Leaf(string data)
        {
            Data = data;
        }

        public string Hash()
        {
            using var hashing = SHA256.Create();
            return string.Concat(Array.ConvertAll(hashing.ComputeHash(Encoding.UTF8.GetBytes(Data)),
                x => x.ToString("X2")));
        }
    }
}