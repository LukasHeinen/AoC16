using System;
using System.Collections.Generic;
using System.Linq;

namespace Day19
{
    public static class Program
    {
        static void Main(string[] args)
        {

            var elements = new int[3001330];
            for (var i = 0; i < elements.Length; i++)
            {
                elements[i] = i + 1;
            }

            var elementsList = elements.ToList();

            var pos = 0;
            var count = elementsList.Count;
            while (count > 1)
            {
                
                var obj = elementsList[pos % count];

                if (count % 2 == 0)
                {
                    elementsList.RemoveAt((pos + count  / 2) % count);
                }
                else
                {
                    elementsList.RemoveAt((pos + (count - 1) / 2) % count);
                }
                count = elementsList.Count;
                pos = (elementsList.IndexOf(obj) + 1) % count;
            }
            // Part 1
                /*
                for (var i = 0; i < elements.Length; i++)
                {
                    if (elements[i].isAlive)
                    {
                        elements[(i + 1) % elements.Length].isAlive = false;
                    }
                }

                var newElements = elements.Where(e => e.isAlive).ToArray();
                elements = newElements;
                */
            Console.WriteLine(elementsList[0]);
            Console.ReadLine();
        }
        
    }

    public class Element
    {
        public int Index {get; set; }
        public bool isAlive { get; set; }
    }
}
