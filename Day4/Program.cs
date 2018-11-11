using System;
using System.Runtime.InteropServices;
using Core;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var strings = InputFileReader.ReadAllLines("Input.txt");
            var unlocker = new Unlocker(strings);
            Console.WriteLine(unlocker.GenerateSectorSum());
            unlocker.GetSectorIdOfRequiredRoom();
            Console.ReadLine();
        }
    }
}
