using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlockchainTechnology
{
    public class MerkleTree
    {
        public List<Leaf> Leaves = new();
        public MerkleTree LeftMerkleTree { get; set; }
        public MerkleTree RightMerkleTree { get; set; }

        public string Digest => ComputeDigest();


        public MerkleTree(params Leaf[] leaves)
        {
            Leaves.AddRange(leaves);
        }

        private string ComputeDigest()
        {
            using var hashing = SHA256.Create();
            var concatenated = Leaves.Count > 0
                ? string.Join("", Leaves.Select(x => x.Hash()))
                : LeftMerkleTree.ComputeDigest() + RightMerkleTree.ComputeDigest();

            return string.Concat(Array.ConvertAll(
                hashing.ComputeHash(Encoding.UTF8.GetBytes(concatenated)),
                x => x.ToString("X2")));
        }

        public void Add(MerkleTree left, MerkleTree right)
        {
            LeftMerkleTree = left;
            RightMerkleTree = right;
        }

        public void PrintTree(int depth = 0)
        {
            Console.WriteLine(new string('-', depth) + $"[Depth {depth}] Hash: {ComputeDigest()}" +
                           (Leaves.Count > 0
                               ? " - " + Leaves.Select(x => x.Data)
                                   .Aggregate((current, next) => current + ", " + next)
                               : ""));
            LeftMerkleTree?.PrintTree(depth + 1);
            RightMerkleTree?.PrintTree(depth + 1);
        }
    }
}