using System;
using System.Runtime.InteropServices;
using Core;
using Day4;

namespace Day4
{
    public static class Program
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
