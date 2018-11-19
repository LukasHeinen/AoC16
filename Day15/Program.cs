using System;

namespace Day15
{
    public static class Program
    {
        static void Main(string[] args)
        {
            
            var discs = new [,] {
                {17,1},
                {7,0},
                {19,2},
                {5,0},
                {3,0},
                {13,5},
                {11,0}
            };
            
            
            var notFound = true;
            var count = -1;
            while (notFound)
            {
                count++;
                var allValid = true;
                for (var i = 0; i < discs.Length/discs.Rank; i++)
                {
                    var mod = (discs[i,1] + i + count + 1) % discs[i,0];
                    if (mod != 0)
                    {
                        allValid = false;
                        break;
                    }
                }
                
                if (allValid) notFound = false;
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
