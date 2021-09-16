using System;

namespace BlockchainTechnology
{
    class Program
    {
        static void Main(string[] args)
        {
            var merkleTreeLevel3Left = new MerkleTree(new Leaf("Anivia"), new Leaf("Jayce"));
            var merkleTreeLevel3Right = new MerkleTree(new Leaf("Annie"), new Leaf("Nocturne"), new Leaf("Nautilus"));
            var merkleTreeLevel3RightRight = new MerkleTree(new Leaf("Jax"), new Leaf("Neeko"));
            var merkleTreeLevel3LeftLeft = new MerkleTree(new Leaf("Graves"), new Leaf("Pyke"));

            var merkleTreeLevel2Right = new MerkleTree();
            merkleTreeLevel2Right.Add(merkleTreeLevel3Right, merkleTreeLevel3RightRight);
            var merkleTreeLevel2Left = new MerkleTree();
            merkleTreeLevel2Left.Add(merkleTreeLevel3Left, merkleTreeLevel3LeftLeft);

            var merkleTree = new MerkleTree();
            merkleTree.Add(merkleTreeLevel2Left, merkleTreeLevel2Right);

            merkleTree.PrintTree();
            
            Console.WriteLine(Environment.NewLine + "---------------------" + Environment.NewLine);


            merkleTreeLevel2Right.LeftMerkleTree.Leaves[2].Data = "Hello";
            merkleTree.PrintTree();
        }
    }
}