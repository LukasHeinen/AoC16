using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;

namespace NetCore
{
    public class PathCalculator
    {
        private List<Tuple<string, int>> _sequence;
        private HashSet<Tuple<int, int>> _visitedLocations= new HashSet<Tuple<int, int>>();
        private int _currentDirection = 0;
        private int _currentNorth = 0;
        private int _currentEast = 0;

        public PathCalculator(string input)
        {
            _sequence = generateSequenceFromString(input);
        }

        private List<Tuple<string, int>> generateSequenceFromString(string input)
        {
            var strings = input.Split(", ");
            var list = new List<Tuple<string, int>>();
            foreach (var s in strings)
            {
                list.Add(new Tuple<string, int>(s.ToCharArray()[0].ToString(), int.Parse(s.Substring(1))));
            }
            return list;
        }

        public int run()
        {
            try
            {
                while (_sequence.Any())
                {
                    doStep(_sequence.First().Item1, _sequence.First().Item2);
                    _sequence.RemoveAt(0);
                }
            }
            catch (Exception)
            {
                // Gotcha
            }

            return Math.Abs(_currentNorth) + Math.Abs(_currentEast);
        }

        public bool doStep(string direction, int steps)
        {
            if (turn(direction))
            {
                walk(steps);
            }
           
            return true;
        }

        private bool turn(string direction)
        {
            switch (direction)
            {
                case "L":
                {
                    _currentDirection = (_currentDirection - 1) % 4;
                    break;
                }
                case "R":
                {
                    _currentDirection = (_currentDirection + 1) % 4;
                    break;
                }
                default:
                {
                    return false;
                }
            }

            if (_currentDirection < 0)
            {
                _currentDirection += 4;
            }
            return true;
        }

        private void walk(int steps)
        {
            var stepsToGo = steps;
            while (stepsToGo > 0)
            {
                switch (_currentDirection)
                {
                    case 0:
                    {
                        _currentNorth += 1;
                        break;
                    }

                    case 1:
                    {
                        _currentEast += 1;
                        break;
                    }

                    case 2:
                    {
                        _currentNorth -= 1;
                        break;
                    }

                    case 3:
                    {
                        _currentEast -= 1;
                        break;
                    }
                    default:
                    {
                        throw new NotImplementedException();
                    }
                }

                stepsToGo -= 1;

                if (!_visitedLocations.Add(new Tuple<int, int>(_currentNorth, _currentEast)))
                {
                    throw new Exception();
                }
            }
        }
    }
}
