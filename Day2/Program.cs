using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Day2
{
    class Program
    {
        private static Unlocker _unlocker;
        private static Unlocker _unlocker2;
        public static void Main()
        {
            _unlocker = new Unlocker();
            _unlocker2 = new Unlocker(2);

            var inputCodes = InputFileReader.ReadAllLines("Input.txt");
            
            Console.WriteLine("Task1: " + _unlocker.GetCode(inputCodes));
            Console.WriteLine("Task2: " + _unlocker2.GetCode(inputCodes));

            Console.ReadLine();
        }
    }
}
