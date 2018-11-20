using System;

namespace Day18
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var rows = new string[400000];
            var input = ".^^^^^.^^.^^^.^...^..^^.^.^..^^^^^^^^^^..^...^^.^..^^^^..^^^^...^.^.^^^^^^^^....^..^^^^^^.^^^.^^^.^^";

            rows[0] = input;
            for (var i = 1; i < rows.Length; i++)
            {
                rows[i] = RowGenerator.Generate(rows[i - 1]);
            }

            var count = 0;
            foreach (var row in rows)
            {
                foreach (var c in row)
                {
                    if (c.Equals('.')) count++;
                }
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
