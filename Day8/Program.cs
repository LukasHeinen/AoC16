using System;
using Core;

namespace Day8
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var screen = new Screen(6, 50);
            var commands = InputFileReader.ReadAllLines("Input.txt");
            foreach (var command in commands)
            {
                screen.ExecuteCommand(command);
            }

            var count = screen.GetCount();
            var screenOutput = screen.GetScreen();
            Console.WriteLine(count);
            foreach (var s in screenOutput)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
}
