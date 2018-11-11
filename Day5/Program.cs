using System;

namespace Day5
{
    public static class Program
    {
        private static readonly string _input = "uqwqemis";

        public static void Main(string[] args)
        {
            var passwordGenerator= new PasswordGenerator();

            var password1 = passwordGenerator.ComputePassword(_input);
            var password2 = passwordGenerator.ComputePassword2(_input);
            Console.WriteLine(password1);
            Console.WriteLine(password2);
            Console.ReadLine();
        }
    }
}
