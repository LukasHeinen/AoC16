using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Day3
{
    public static class TriangleEvaluator
    {
        private static string[] _rawTriangles;
        private static List<Triangle> _triangles;

        public static void Main()
        {
            _rawTriangles = InputFileReader.ReadAllLines("Input.txt");
            _triangles = new List<Triangle>();
            
            Task1();
            _triangles.Clear();
            Task2();

            Console.ReadLine();
        }

        public static void Task1()
        {
            foreach (var rawTriangle in _rawTriangles)
            {
                var strings = rawTriangle.Split(" ");
                var i = new List<int>();
                foreach (var s in strings)
                {
                    if (int.TryParse(s, out var res)) i.Add(res);
                }

                _triangles.Add(new Triangle(i.ToArray()));
            }

            var count = 0;
            foreach (var t in _triangles)
            {
                if (t.IsValid()) count++;
            }
            Console.WriteLine("Task1: " + count);
        }

        public static void Task2()
        {
            var i1 = new List<int>();
            var i2 = new List<int>();
            var i3 = new List<int>();

            foreach (var rawTriangle in _rawTriangles)
            {
                var strings = rawTriangle.Split(" ");
                var p = 0;
                var i = new List<int>();
                foreach (var s in strings)
                {
                    if (int.TryParse(s, out var res)) i.Add(res);
                }

                i1.Add(i.ToArray()[0]);
                i2.Add(i.ToArray()[1]);
                i3.Add(i.ToArray()[2]);
            }

            var c = 0;
            var d = new int[3];
            var e = new int[3];
            var f = new int[3];

            for (var i = 0; i < i1.Count; i++)
            {
                d[c] = i1[i];
                e[c] = i2[i];
                f[c] = i3[i];
                c++;
                if (c == 3)
                {
                    _triangles.Add(new Triangle(d));
                    _triangles.Add(new Triangle(e));
                    _triangles.Add(new Triangle(f));
                    c = 0;
                    d = new int[3];
                    e = new int[3];
                    f = new int[3];
                }
            }

            var count = 0;
            foreach (var t in _triangles)
            {
                if (t.IsValid()) count++;
            }
            Console.WriteLine("Task2: " + count);
        }
    }
}
