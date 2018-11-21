using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Day20
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var input = InputFileReader.ReadAllLines("Input.txt");
            var max = uint.MaxValue;

            var boundarys = new uint[input.Length, 2];
            for (var i = 0; i < input.Length; i++)
            {
                var split = input[i].Split("-");
                boundarys[i, 0] = uint.Parse(split[0]);
                boundarys[i, 1] = uint.Parse(split[1]);
            }


            var list = new List<Tuple<uint, uint>>();
            for (var i1 = 0; i1 < boundarys.Length / 2; i1++)
            {
                list.Add(new Tuple<uint, uint>(boundarys[i1, 0], boundarys[i1, 1]));
            }

            var count = 0;
            var sortedList = list.OrderBy(i => i.Item1).ThenBy(i => i.Item2).ToList();
            var toBeRemoved = new List<int>();
            do
            {
                toBeRemoved.Clear();
                for (var i = 0; i < sortedList.Count - 1; i++)
                {
                    if (!toBeRemoved.Contains(i) && sortedList[i + 1].Item2 <= sortedList[i].Item2)
                    {
                        toBeRemoved.Add(i + 1);
                    }
                }

                for (var i = toBeRemoved.Count - 1; i >= 0; i--)
                {
                    sortedList.RemoveAt(toBeRemoved[i]);
                }
            } while (toBeRemoved.Count > 0);

            uint idx = 0;
            var idxList = 0;
            var goneThrough = false;
            while (idx < max && !goneThrough)
            {
                uint current = sortedList[idxList].Item1;
                for (var i = idx; i < current; i++)
                {
                    count++;
                }

                current = sortedList[idxList].Item2;
                if (current == uint.MaxValue)
                {
                    idx = current;
                    break;
                }

                while (true)
                {
                    if (idxList + 1 == sortedList.Count)
                    {
                        idx = current + 1;
                        goneThrough = true;
                        break;
                    }

                    idxList++;
                    var endOfNext = sortedList[idxList].Item2;
                    if (current >= sortedList[idxList].Item1 && current <= endOfNext)
                    {
                        current = endOfNext;
                    }
                    else
                    {
                        idx = current + 1;
                        break;
                    }
                }

            }

            for (var i = idx; i < max; i++)
            {
                count++;
            }

            Console.WriteLine(count + "");

            Console.ReadLine();
        }
    }
}
