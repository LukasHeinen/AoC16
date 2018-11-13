using System.Text;
using Core;

namespace Day8
{
    public class Screen
    {
        private int _height;
        private int _width;
        private char[,] _screen;

        public Screen(int height, int width)
        {
            _height = height;
            _width = width;
            _screen = new char[_height, _width];
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    _screen[i, j] = '.';
                }
            }
        }

        public void ExecuteCommand(string command)
        {
            var s = command.Split(" ");
            if (s[0].Equals("rect"))
            {
                Rect(int.Parse(s[1].Split("x")[0]), int.Parse(s[1].Split("x")[1]));
            } else
            { 
                switch (s[1])
                {
                    case "column":
                    {
                        RotateCol(int.Parse(s[2].Split("=")[1]), int.Parse(s[4]));
                            break;
                    }
                    case "row":
                    {
                        RotateRow(int.Parse(s[2].Split("=")[1]), int.Parse(s[4]));
                        break;
                    }
                }
            }
        }
            
        private void Rect(int x, int y)
        {
            for (var i = 0; i < y; i++)
            {
                for (var j = 0; j < x; j++)
                {
                    _screen[i,j] = '#';
                }
            }
        }

        private void RotateRow(int rowIndex, int count)
        {
            Shift(rowIndex, count);
        }

        public void RotateCol(int colIndex, int count)
        {
            Transpose();
            Shift(colIndex, count);
            Transpose();
        }

        public string[] GetScreen()
        {
            return ToStrings();
        }

        public int GetCount()
        {
            var count = 0;
            foreach (var c in _screen)
            {
                if (c.Equals('#')) count++;
            }

            return count;
        }

        private string[] ToStrings()
        {
            var builders = new StringBuilder[_height];
            for (var i = 0; i < builders.Length; i++)
            {
                builders[i] = new StringBuilder();
            }
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    builders[i].Append(_screen[i, j]);
                }
            }

            var res = new string[_height];
            for (var i = 0; i < res.Length; i++)
            {
                res[i] = builders[i].ToString();
            }

            return res;
        }

        private void ToArray(string[] input)
        {
            _height = input.Length;
            _width = input[0].Length;
            _screen = new char[input.Length,input[0].Length];
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    _screen[i,j] = input[i][j];
                }
            }
        }

        private void Shift(int rowIndex, int count)
        {
            var screen = ToStrings();
            var s = screen[rowIndex];
            var newS = s.ToCharArray();
            for (var i = 0; i < s.Length; i++)
            {
                newS[(i + count) % s.Length] = s[i];
            }

            screen[rowIndex] = new string(newS);
            ToArray(screen);
        }

        private void Transpose()
        {
            var screen = ToStrings();
            screen = InputTransposer.Convert(screen);
            ToArray(screen);
        }
    }
}