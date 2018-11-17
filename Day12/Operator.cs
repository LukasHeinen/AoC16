using System;
using System.Collections.Generic;
using System.Text;

namespace Day12
{
    public class Operator
    {
        private readonly int[] _register;
        private readonly string[] _operations;
        private int _currentOperationIndex;

        public Operator(string[] ops)
        {
            _register = new [] {0,0,1,0};
            _operations = ops;
            _currentOperationIndex = 0;
        }

        public void Run()
        {
            for (_currentOperationIndex = 0; _currentOperationIndex < _operations.Length; _currentOperationIndex++)
            {
                var op = _operations[_currentOperationIndex].Split(" ");
                switch (op[0])
                {
                    case "cpy":
                    {
                        if (int.TryParse(op[1], out var x))
                        {
                            Copy(x, op[2][0]);
                        }
                        else
                        {
                            Copy(op[1][0], op[2][0]);
                        }
                        break;
                    }
                    case "inc":
                    {
                        Inc(op[1][0]);
                        break;
                    }
                    case "dec":
                    {
                        Dec(op[1][0]);
                        break;
                    }
                    case "jnz":
                    {
                        if (int.TryParse(op[2], out var y))
                        {
                            if (int.TryParse(op[1], out var x))
                            {
                                Jnz(x, y);
                            }
                            else
                            {
                                Jnz(op[1][0], y);
                            }
                        }

                        break;
                    }
                }
            }
        }

        public int GetResult(char x)
        {
            return _register[GetIndex(x)];
        }

        public void Copy(int x, char y)
        {
            var index = GetIndex(y);
            _register[index] = x;
        }

        public void Copy(char x, char y)
        {
            var index = GetIndex(y);
            _register[index] = _register[GetIndex(x)];
        }

        public void Inc(char x)
        {
            _register[GetIndex(x)] += 1;
        }

        public void Dec(char x)
        {
            _register[GetIndex(x)] -= 1;
        }

        public void Jnz(int x, int y)
        {
            if (x != 0)
            {
                _currentOperationIndex += (y-1);
            }
        }

        public void Jnz(char x, int y)
        {
            if (_register[GetIndex(x)] != 0)
            {
                _currentOperationIndex += (y-1);
            }
        }

        private int GetIndex(char c)
        {
            return c - 'a';
        }
    }
}
