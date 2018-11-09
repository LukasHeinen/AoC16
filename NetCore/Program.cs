using System;
using System.Collections.Generic;
using System.Text;
using Day1;
using NetCore;

namespace Day1
{
    public class Program
    {
        private static PathCalculator calc;
        public static void Main()
        {
            calc = new PathCalculator(Input.inputSequence);
            var res = calc.run();
            Console.WriteLine("Result " + res);
            Console.ReadLine();
        }
    }
}
