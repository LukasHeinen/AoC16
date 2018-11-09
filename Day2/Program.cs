using System;
using Core;

namespace Day2
{
    public static class Program
    {
        public static void Main()
        {
            var unlocker = new Unlocker();
            var unlocker2 = new Unlocker(2);

            var inputCodes = InputFileReader.ReadAllLines("Input.txt");

            Console.WriteLine("Task1: " + unlocker.GetCode(inputCodes));
            Console.WriteLine("Task2: " + unlocker2.GetCode(inputCodes));

            Console.ReadLine();
        }
    }
}
