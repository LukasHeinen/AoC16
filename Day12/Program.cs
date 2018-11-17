using System;
using Core;

namespace Day12
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var operations = InputFileReader.ReadAllLines("Input.txt");

            var op = new Operator(operations);
            op.Run();
            Console.WriteLine(op.GetResult('a'));
            Console.ReadLine();
        }
    }
}
