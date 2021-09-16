using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Proof_of_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            var strings = new List<string>();
            for (var i = 0; i < 15; i++)
                strings.Add(RandomString());

            HashCollision h = new HashCollision()
            {
                Target = "0000000000000000"
            };
            List<TimeSpan> elapsed = new List<TimeSpan>();

            foreach (var s in strings)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                h.Collide(s);
                sw.Stop();
                elapsed.Add(sw.Elapsed);
                Console.WriteLine($"Solution found for: {s}, took {sw.Elapsed.TotalSeconds} seconds");
            }

            double average = elapsed.Average(x => x.TotalSeconds);

            Console.WriteLine($"Average time: {average} seconds");
        }

        public static string RandomString()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 27)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}