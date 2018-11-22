using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Core;

namespace Day21
{
    public static class Program
    {
        private static bool _reverse = true;
        static void Main(string[] args)
        {
            var c = _reverse ? "fbgdceah".ToCharArray() : "abcdefgh".ToCharArray();
            
            var input = InputFileReader.ReadAllLines("Input.txt");
           

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
                            var swap = new LetterSwap(s[2][0], s[5][0]);
                            operations.Add(swap);
                        }
                        break;
                    }
                    case "rotate":
                    {
                        if (s[1].Equals("left"))
                        {
                            if (_reverse)
                            {
                                var rot = new Rotate(+int.Parse(s[2]), 0);
                                operations.Add(rot);
                            }
                            else
                            {
                                var rot = new Rotate(-int.Parse(s[2]), 0);
                                operations.Add(rot);
                            }

                            break;
                        }

                        if (s[1].Equals("right"))
                        {
                            if (_reverse)
                            {
                                var rot = new Rotate(-int.Parse(s[2]), 0);
                                operations.Add(rot);
                            }
                            else
                            {
                                var rot = new Rotate(+int.Parse(s[2]), 0);
                                operations.Add(rot);
                            }
                            break;
                        }
                        
                        var pos = s[6][0];
                        var rot1 = new Rotate(pos, pos, _reverse);
                        operations.Add(rot1);
                        break;

                    }
                    case "_reverse":
                    {
                        var rev = new Reverse(int.Parse(s[2]), int.Parse(s[4]));
                        operations.Add(rev);
                        break;
                    }
                    case "move":
                    {
                        if (_reverse)
                        {
                            var mov = new Move(int.Parse(s[5]), int.Parse(s[2]));
                            operations.Add(mov);
                            }
                        else
                        {
                            var mov = new Move(int.Parse(s[2]), int.Parse(s[5]));
                            operations.Add(mov);
                            }
                        
                        break;
                    }
                }
            }

            if (_reverse)
            {
                for (var i = 0; i < operations.Count; i++)
                {
                    operations[operations.Count-1-i].Do(ref c);
                }
            }
            else
            {
                foreach (var operation in operations)
                {
                    operation.Do(ref c);
                }
            }

            
            Console.WriteLine(c);
            Console.ReadLine();
        }
    }

    interface IOperation
    {
        void Do(ref char[] c);
    }

    public class PosSwap : IOperation
    {
        private readonly int _x;
        private readonly int _y;
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

    public class Rotate : IOperation
    {
        private int _x;
        private int _y;
        private readonly bool _reverse;
        private bool _addition = false;

        public Rotate(int x, int y, bool reverse = false)
        {

            _x = x;
            _y = y;
            _reverse = reverse;
        }

        public void Do(ref char[] c)
        {
            var newC = new char[c.Length];
            if (_y != 0)
            {
                if (_reverse)
                {
                    _y = c.ToList().IndexOf((char) _y);
                    if (_y == 1) _y = 5;
                    else if (_y == 3) _y = 4; 
                    else if (_y == 7) _y = 3; 
                    else if (_y == 5)
                    {
                        _y = 3;
                        _addition = true;
                    } 
                    else if (_y == 2) _y = 1; 
                    else if (_y == 4) _y = 0; 
                    else if (_y == 6) _y = 6; 
                    else if (_y == 0) _y = 5; 
                }
                else
                {
                    _y = c.ToList().IndexOf((char)_y);
                }

                    _x = _y;

                    for (var i = 0; i < c.Length; i++)
                    {
                        newC[(i + 1) % newC.Length] = c[i].ToString()[0];
                    }
                Array.Copy(newC, c, c.Length);
                if (_addition)
                {
                    for (var i = 0; i < c.Length; i++)
                    {
                        newC[(i + 1) % newC.Length] = c[i].ToString()[0];
                    }
                }
                
                Array.Copy(newC, c, c.Length);
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

    public class Reverse : IOperation
    {
        private readonly int _x;
        private readonly int _y;

        public Reverse(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public void Do(ref char[] c)
        {
            var newC = c.ToList();
            for (var i = 0; i <= _y-_x; i++)
            {
                c[i+_x] = newC[_y - i].ToString()[0];
            }
        }
    }

    public class Move : IOperation
    {
        private readonly int _x;
        private readonly int _y;
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

    public class LetterSwap : IOperation
    {
        private readonly int _x;
        private readonly int _y;
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