using System;
using System.Reflection.Metadata;
using System.Threading;

namespace Day13
{
    public static class Program
    {
        private static int _number = 1364;
        private static readonly Tuple<int, int> _startingLocation = new Tuple<int, int>(1, 1);
        private static readonly Tuple<int, int> _goal = new Tuple<int, int>(31, 39);
        static void Main(string[] args)
        {
            Maze.Algorithm al = (x, y) =>
            {
                var z = x * x + 3 * x + 2 * x * y + y + y * y + _number;
                var bin = Convert.ToString(z, 2);
                var count = 0;
                foreach (var c in bin)
                {
                    if (c.Equals('1'))
                    {
                        count++;
                    }
                }

                if ((count % 2) == 0)
                {
                    return ".";
                }
                return "#";
            };

            var maze = new Maze(al, _startingLocation, _goal);
            maze.Run();
        }
    }
}
