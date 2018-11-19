using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Core;
using Day5;

namespace Day14
{
    public static class Program
    {
        private static readonly string _salt = "ngcjuoqr";
        private static int _globalCount = 0;
        private static int _count = 0;

        private static string[] _cachedHashes;

        private static HashGenerator gen;

        public static void Main(string[] args)
        {
            _cachedHashes = new string[40000];
            for (int i = 0; i < 40000; i++)
            {
                _cachedHashes[i] = "";
            }
            Run();
            Print();
        }

        private static void Run()
        {
            gen = new HashGenerator();
            GenerateBrtualHashes();

            var success = false;
            while (!success)
            {
                var hash1 = _cachedHashes[_count];

                for (var i = 0; i < hash1.Length - 2; i++)
                {
                    var substring = hash1.Substring(i, 3);
                    var set = new HashSet<char>();
                    foreach (var c in substring)
                    {
                        set.Add(c);
                    }

                    if (set.Count == 1)
                    {
                        var c = set.Take(1).First();
                        set.Clear();
                        if (ValidateHash(c))
                        {
                            _globalCount++;
                            if (_globalCount == 64 || _count > 38000)
                            {
                                success = true;
                            }
                        }
                        break;
                    }
                }
                _count++;
            }
        }

        private static void GenerateBrtualHashes()
        {
            for (int i = 0; i < 40000; i++)
            {
                var s = _salt + i;
                var hash1 = gen.ComputeFullHash(s).ToLower();
                for (var j = 1; j < 2017; j++)
                {
                    hash1 = gen.ComputeFullHash(hash1).ToLower();
                }

                _cachedHashes[i] = hash1;
            }
        }
        private static bool ValidateHash(char c)
        {
            var sequence = "" + c + c + c + c + c;
            
            for (var j = 1; j <= 1000; j++)
            {
                var hash2 = _cachedHashes[_count + j];
                if (hash2.Contains(sequence))
                {
                    return true;
                }
            }
            return false;
        }

        private static void Print()
        {
            Console.WriteLine(_count-1);
            Console.ReadLine();
            
        }
    }
}