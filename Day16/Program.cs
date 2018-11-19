using System;
using System.Text;

namespace Day16
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var discLength = 35651584;
            var input = "01111010110010011";
            var output = input;
            while (output.Length < discLength)
            {
                var outputBuilder = new StringBuilder();
                var reverse = BuildReverse(output);
                outputBuilder.Append(output);
                outputBuilder.Append("0");
                outputBuilder.Append(reverse);
                output = outputBuilder.ToString();
            }

            output = output.Substring(0,discLength);
            var checksum = output;
            #pragma warning disable S1116 // Empty statements should be removed
            while (!HasFinalChecksum(checksum, out checksum)) ;
            
            Console.WriteLine(checksum);
            Console.ReadLine();
        }

        private static string BuildReverse(string input)
        {
            var reverseBuilder = new StringBuilder();
            var str = input;
            var len = str.Length;
            for (var i = 0; i < len; i++)
            {
                reverseBuilder.Append((int.Parse(str[len-i-1] + "") + 1) % 2);
            }

            return reverseBuilder.ToString();
        }

        private static bool HasFinalChecksum(string input, out string checksum)
        {
            var sum = 0;
            var builder = new StringBuilder();
            for (var i = 0; i < input.Length; i+=2)
            {
                if (IsEven(input.Substring(i, 2)))
                {
                    sum++;
                    builder.Append("1");
                }
                else
                {
                    builder.Append("0");
                }
            }
            checksum = builder.ToString();
            return !IsEven(checksum.Length);
        }

        private static bool IsEven(string input)
        {
            var sum = 0;
            foreach (var c in input)
            {
                sum += int.Parse(c + "");
            }

            return (sum % 2 == 0) ;
        }

        private static bool IsEven(int input)
        {
            return (input % 2 == 0);
        }
    }
}
