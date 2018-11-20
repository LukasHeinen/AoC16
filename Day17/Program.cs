using System;
using System.Collections.Generic;
using System.Linq;

namespace Day17
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var pathfinder = new Pathfinder(3,3);
            var initialState = new Tuple<int[], string>(new[] {0,0}, "edjrjqaa");

            var currentSearch = new List<Tuple<int[], string>>();
            var min = int.MinValue;
            currentSearch.Add(initialState);
            while (true)
            {
                var goal = currentSearch.Where(t => Equals(t, new[] {3, 3})).ToArray(); 
                    foreach (var tuple in goal)
                    {
                        if (tuple.Item2.Substring(8).Length > min) min = tuple.Item2.Substring(8).Length;
                    }

                currentSearch.RemoveAll(t => Equals(t, new[] {3, 3}));
                if (currentSearch.Count == 0) break;
                var nextStates = new List<Tuple<int[], string>>();
                foreach (var tuple in currentSearch)
                {
                    var transitions = pathfinder.GetValidDirections(tuple);
                    if (transitions != null)
                    {
                        foreach (var transition in transitions)
                        {
                            var newState = pathfinder.ExecuteTransition(tuple, transition);
                            nextStates.Add(newState);
                        }
                    }
                }
                currentSearch.Clear();
                currentSearch = nextStates;
            }

            Console.WriteLine(min);
            Console.ReadLine();
        }

        private static bool Equals(Tuple<int[], string> state, int[] goal)
        {
            var posX = state.Item1[0];
            var posY = state.Item1[1];

            return (posX == goal[0] && posY == goal[1]);
        }
    }
}
