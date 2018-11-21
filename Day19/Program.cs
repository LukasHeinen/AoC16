using System;
using System.Collections.Generic;
using System.Linq;

namespace Day19
{
    public static class Program
    {
        private static bool part2 = false;
        static void Main(string[] args)
        {
            var elements1 = new Element[3001330];
            var elements2 = new int[3001330];
            for (var i = 0; i < elements2.Length; i++)
            {
                elements1[i] = new Element() { Index = i, isAlive = true };
                elements2[i] = i + 1;
            }
            var elementsList = elements2.ToList();

            if (part2)
            {
                var pos = 0;
                var count = elementsList.Count;
                while (count > 1)
                {
                    var obj = elementsList[pos % count];

                    if (count % 2 == 0)
                    {
                        elementsList.RemoveAt((pos + count / 2) % count);
                    }
                    else
                    {
                        elementsList.RemoveAt((pos + (count - 1) / 2) % count);
                    }

                    count = elementsList.Count;
                    pos = (elementsList.IndexOf(obj) + 1) % count;
                }
                Console.WriteLine(elementsList[0]);
            }
            else
            {
                var time = System.Diagnostics.Stopwatch.StartNew();
                while (elements1.Length > 1)
                {
                    for (var i = 0; i < elements1.Length; i++)
                    {
                        if (elements1[i].isAlive)
                        {
                            elements1[(i + 1) % elements1.Length].isAlive = false;
                        }
                    }

                    var newElements = elements1.Where(e => e.isAlive).ToArray();
                    elements1 = newElements;
                }
                time.Stop();
                Console.WriteLine("Time: " + time.ElapsedMilliseconds);
                Console.WriteLine(elements1[0].Index);
            }

            
            Console.ReadLine();
        }
    }

    public class Element
    {
        public int Index { get; set; }
        public bool isAlive { get; set; }
    }
}