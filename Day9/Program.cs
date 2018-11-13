using System;
using Core;

namespace Day9
{
    public static class Program
    {
        public static void Main()
        {
            var code = new Code(InputFileReader.ReadAllLines("Input.txt")[0]);

            var res = code.DecompressAndCount2();

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}