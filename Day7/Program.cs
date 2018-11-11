using System;
using Core;

namespace Day7
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var input = InputFileReader.ReadAllLines("Input.txt");
            var tlsCount = 0;
            var sslCount = 0;
            foreach (var s in input)
            {
                var address = new IpAddress(s);
                if (address.SupportsTls()) tlsCount++;
                if (address.SupportsSsl()) sslCount++;
            }

            Console.WriteLine("TLS count: " + tlsCount);
            Console.WriteLine("SSL count: " + sslCount);
            Console.ReadLine();
        }
    }
}
