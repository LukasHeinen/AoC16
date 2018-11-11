using System;
using Core;

namespace Day6
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var strings = InputFileReader.ReadAllLines("Input.txt");
            var convertedStrings = InputConverter.Convert(strings);

            var simplifiedString1 = Simplifier.Simplify(convertedStrings);
            var simplifiedString2 = Simplifier.Simplify(convertedStrings, false);
            Console.WriteLine("Task 1: " + simplifiedString1);
            Console.WriteLine("Task 2: " + simplifiedString2);
            Console.ReadLine();
        }
    }
}
