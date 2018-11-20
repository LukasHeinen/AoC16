using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;

namespace Day18
{
    public static class RowGenerator
    {
        public static string Generate(string row)
        {
            var extendedRow = "." + row + ".";
            var newRow = new StringBuilder();
            for (var i = 0; i < extendedRow.Length - 2; i++)
            {
                var substring = extendedRow.Substring(i, 3);
                if (ProducesATrap(substring))
                {
                    newRow.Append("^");
                }
                else
                {
                    newRow.Append(".");
                }
            }

            return newRow.ToString();
        }

        private static bool ProducesATrap(string input)
        {
            if (input.Length != 3) throw new Day18Exception();
            if (
                input[0].Equals('^') && input[1].Equals('^') && input[2].Equals('.') ||
                input[0].Equals('.') && input[1].Equals('^') && input[2].Equals('^') ||
                input[0].Equals('^') && input[1].Equals('.') && input[2].Equals('.') ||
                input[0].Equals('.') && input[1].Equals('.') && input[2].Equals('^')
            )
            {
                return true;
            }
            return false;
        }
    }
}