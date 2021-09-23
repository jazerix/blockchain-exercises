using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Proof_of_Work
{
    public class HashCollision
    {
        public string Target { get; set; } = "000000000";

        public void Collide(string input)
        {
            while (!TargetReached(input))
                input = "0" + input;
        }

        private bool TargetReached(string input)
        {
            var encoded = new List<byte>(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(input)));
            var bitString = string.Join("", encoded.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
            
            return Target == bitString[..Target.Length];
        }
    }
}