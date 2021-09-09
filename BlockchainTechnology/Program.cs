using System;

namespace BlockchainTechnology
{
    class Program
    {
        static void Main(string[] args)
        {
            var merkleTreeLevel2Left = new MerkleTree(new Leaf("Anivia"), new Leaf("Jayce"));
            var merkleTreeLevel2Right = new MerkleTree(new Leaf("Annie"), new Leaf("Nocturne"), new Leaf("Nautilus"));
            
            var merkleTree = new MerkleTree();
            merkleTree.Add(merkleTreeLevel2Left, merkleTreeLevel2Right);
            merkleTree.PrintTree();
            
            Console.WriteLine(Environment.NewLine + "---------------------" + Environment.NewLine);

            merkleTreeLevel2Right.Leaves[2].Data = "Hello";
            merkleTree.PrintTree();
        }
    }
}