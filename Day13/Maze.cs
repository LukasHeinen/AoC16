using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Day13
{
    public class Maze
    {
        private static bool _task2 = true;
        private readonly List<string> _maze;

        public delegate string Algorithm(int y, int x);

        private readonly Algorithm _al;
        private readonly Tuple<int, int> _startingPoint;
        private readonly Tuple<int, int> _goal;

        private readonly HashSet<Tuple<int, int>> _reachablePoints;
        private int _depth = 0;
        
        public Maze(Algorithm evalutionFunction, Tuple<int, int> startingPoint, Tuple<int, int> goal)
        {
            _al = evalutionFunction;
            _maze = new List<string>();
            _startingPoint = startingPoint;
            _goal = goal;
            _reachablePoints = new HashSet<Tuple<int, int>>();
        }

        public void Run()
        {
            Extend();
            Extend();
            _reachablePoints.Add(_startingPoint);

            while (true)
            {
                if (Mark()) break;
                Extend();
            }
            Console.WriteLine("Reachable points: " + _reachablePoints.Count);
            Console.ReadLine();
        }

        public void Extend()
        {
            #pragma warning disable S1643 // Strings should not be concatenated using '+' in a loop
            for (var i = 0; i < _maze.Count; i++) _maze[i] += _al(_maze.Count,i);


            _maze.Add("");
            var builder = new StringBuilder();
            for (var j = 0; j < _maze.Count; j++) builder.Append(_al(j,_maze.Count - 1));

            _maze[_maze.Count - 1] = builder.ToString();
        }
    

        public bool Mark()
        {
            _depth++;
            MarkNeibours();
            if (!_task2 && _reachablePoints.Contains(_goal))
            {
                Console.WriteLine(_depth);
                return true;
            }
            if (_task2 && _depth == 50) return true;
            return false;
        }

        private void MarkNeibours()
        {
            var next = new List<Tuple<int, int>>();

            foreach (var tuple in _reachablePoints)
                for (var i = -1; i < 2; i++)
                {
                    for (var j = -1; j < 2; j++)
                    {
                        if (Math.Abs(i)+Math.Abs(j)<2)
                        {

                            var nextY = tuple.Item2 + i;
                            var nextX = tuple.Item1 + j;

                            if (nextX < _maze.Count && nextY < _maze.Count && nextX >= 0 && nextY >= 0 && _maze[nextY][nextX].Equals('.')) next.Add(new Tuple<int, int>(nextX, nextY));
                        }
                    }
                }

            foreach (var tuple in next)
            {
                _reachablePoints.Add(tuple);
            }
        }
    }
}