using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Day11.data;

namespace Day11
{
    public static class TransactionGenerator
    {
        public static List<Transaction> GetAllValidTransactions(State state)
        {
            var objects = state.Floors[state.ElevatorPosition].GetAll();
            var numberOfObjects = objects.Count;
            var maxAsBinary = new StringBuilder();
            for (var i = 0; i < numberOfObjects; i++)
            {
                maxAsBinary.Append("1");
            }

            var max = Convert.ToInt32(maxAsBinary.ToString(), 2);
            var selectors = GetAllCombinationsMax2Objects(max);

            var allTransactions = new List<Transaction>();
            foreach (var selector in selectors)
            {
                var objs = new List<string>();
                foreach (var i in selector)
                {
                    objs.Add(objects.ToList()[i]);
                }

                var allowToGoDown = AllowGoDown(state);
                if (objs.Count > 1)
                {
                    if (objs[0][0] == objs[1][0] || objs[0][1] == objs[1][1])
                    {
                        if (state.ElevatorPosition < state.Floors.Count - 1)
                        {
                            allTransactions.Add(new Transaction()
                            {
                                Direction = 1,
                                Objects = new[] {objs[0], objs[1]}
                            });
                        }

                        if (allowToGoDown && objs[0][0] != objs[1][0])
                        {
                            allTransactions.Add(new Transaction()
                            {
                                Direction = -1,
                                Objects = new[] {objs[0], objs[1]}
                            });
                        }
                    }
                }
                else
                {
                    if (state.ElevatorPosition < state.Floors.Count - 1)
                    {
                        allTransactions.Add(new Transaction()
                        {
                            Direction = 1,
                            Objects = new[] {objs[0]}
                        });
                    }

                    if (allowToGoDown)
                    {
                        allTransactions.Add(new Transaction()
                        {
                            Direction = -1,
                            Objects = new[] {objs[0]}
                        });
                    }
                }
            }

            return allTransactions;
        }

        public static bool AllowGoDown(State state)
        {
             return (state.ElevatorPosition > 0 && state.ElevatorPosition > state.GetEmptiness());
        }

        private static List<int[]> GetAllCombinationsMax2Objects(int max)
        {
            var maxLength = Convert.ToString(max, 2).Length;
            var options = new List<int[]>();
            for (var i = 0; i <= max; i++)
            {
                if (i > Convert.ToInt32("11".PadRight(maxLength,'0'), 2)) break;
                var b = Convert.ToString(i, 2);
                var asBinary = b.PadLeft(maxLength,'0');

                if (OnesAreValid(asBinary))
                {
                    var pos = new List<int>();
                    for (var i1 = 0; i1 < asBinary.Length; i1++)
                    {
                        if (asBinary[i1].Equals('1'))
                        {
                            pos.Add(i1);
                            if (pos.Count == 2) break;
                        }
                    }

                    options.Add(pos.ToArray());
                }
            }

            return options;
        }

        private static bool OnesAreValid(string input)
        {
            var count = 0;
            foreach (var c in input)
            {
                if (c.Equals('1')) count++;
                if (count > 2) return false;
            }

            return count > 0;
        }
    }
}