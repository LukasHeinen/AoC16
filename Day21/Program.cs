using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Core;

namespace Day21
{
    public static class Program
    {
        static void Main(string[] args)
        {
            // var c = "abcdefgh".ToCharArray();
            // var input = InputFileReader.ReadAllLines("Input.txt");
            var c = "abcde".ToCharArray();
            var input = InputFileReader.ReadAllLines("TestInput.txt");


            var operations = new List<IOperation>();
            foreach (var str in input)
            {
                var s = str.Split(" ");
                switch (s[0])
                {
                    case "swap":
                    {
                        if (s[1].Equals("position"))
                        {
                            var swap = new PosSwap(int.Parse(s[2]), int.Parse(s[5]));
                            operations.Add(swap);
                        }
                        else
                        {
                            var swap = new LetterSwap((int)s[2].ToCharArray()[0], (int)s[5].ToCharArray()[0]);
                            operations.Add(swap);
                        }
                        break;
                    }
                    case "rotate":
                    {
                        if (s[1].Equals("left"))
                        {
                            var rot = new Rotate(-int.Parse(s[2]), 0);
                            operations.Add(rot);
                            break;
                        }

                        if (s[1].Equals("right"))
                        {
                            var rot = new Rotate(-int.Parse(s[2]), 0);
                            operations.Add(rot);
                            break;
                        }

                        var pos = s[6][0];
                        var rot1 = new Rotate(pos, pos);
                        operations.Add(rot1);
                        break;

                    }
                    case "reverse":
                    {
                        var rev = new Reverse();
                        operations.Add(rev);
                        break;
                    }
                    case "move":
                    {
                        var mov = new Move(int.Parse(s[2]), int.Parse(s[5]));
                        operations.Add(mov);
                        break;
                    }
                }
            }

            foreach (var operation in operations)
            {
                operation.Do(ref c);
            }

            Console.WriteLine(c);
            Console.ReadLine();


        }
    }

    interface IOperation
    {
        void Do(ref char[] c);
    }

    class PosSwap : IOperation
    {
        private int _x;
        private int _y;
        public PosSwap(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void Do(ref char[] c)
        {
            var copy = c[_y];
            c[_y] = c[_x];
            c[_x] = copy;
        }
    }

    class Rotate : IOperation
    {
        private int _x;
        private int _y;
        public Rotate(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public void Do(ref char[] c)
        {
            var newC = new char[c.Length];
            if (_y != 0)
            {
                _y = c.ToList().IndexOf((char) _y);

                for (var i = 0; i < c.Length; i++)
                {
                    newC[(i + 1) % newC.Length] = c[i].ToString()[0];
                }

                Array.Copy(c, newC, c.Length);

            }
            
            for (var i = 0; i < c.Length; i++)
            {
                if (_x > 0)
                {
                    newC[(_x + i) % newC.Length] = c[i].ToString()[0];
                }
                else
                {
                    newC[(newC.Length + _x + i) % newC.Length] = c[i].ToString()[0];
                }
            }
            Array.Copy(newC, c, c.Length);

            if (_y != 0 && _y >= 4)
            {
                for (var i = 0; i < c.Length; i++)
                {
                    c[(i + 1) % c.Length] = newC[i].ToString()[0];
                }
            }
        }
    }

    class Reverse : IOperation
    {
        public void Do(ref char[] c)
        {
            var newC = c.ToList();
            for (var i = 0; i < c.Length; i++)
            {
                c[i] = newC[newC.Count - 1 - i].ToString()[0];
            }
        }
    }

    class Move : IOperation
    {
        private int _x;
        private int _y;
        public Move(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void Do(ref char[] c)
        {
            var x = c[_x];
            
            var l = c.ToList();
            l.RemoveAt(_x);
            l.Insert(_y,x);
            c = l.ToArray();
        }
    }

    class LetterSwap : IOperation
    {
        private int _x;
        private int _y;
        public LetterSwap(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public void Do(ref char[] c)
        {
            var l = c.ToList();
            var idx = l.IndexOf((char) _x);
            var idy = l.IndexOf((char) _y);

            c[idx] = (char) _y;
            c[idy] = (char) _x;
        }
    }
}