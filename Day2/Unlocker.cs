using System;
using System.Text;
using Core;

namespace Day2
{
    public class Unlocker
    {
        private readonly string[,] _keyBoard;
        private int _posX;
        private int _posY;

        public Unlocker()
        {
            _keyBoard = new string[3, 3];
            var c = 1;
            for (var i = 0; i < _keyBoard.GetLength(0); i++)
            {
                for (var j = 0; j < _keyBoard.GetLength(1); j++)
                {
                    _keyBoard[i, j] = "" + c;
                    c++;
                }
            }

            _posX = 1;
            _posY = 1;
        }

        public Unlocker(int x)
        {
            _keyBoard = new string[5, 5] ;

            for (var i = 0; i < _keyBoard.GetLength(0); i++)
            {
                for (var j = 0; j < _keyBoard.GetLength(1); j++)
                {
                    _keyBoard[i, j] = "";
                }
            }

            _keyBoard[0, 2] = "1";

            _keyBoard[1, 1] = "2";
            _keyBoard[1, 2] = "3";
            _keyBoard[1, 3] = "4";

            for (var i = 0; i < 5; i++)
            {
                _keyBoard[2, i] = (i + 5).ToString();
            }

            _keyBoard[3, 1] = "A";
            _keyBoard[3, 2] = "B";
            _keyBoard[3, 3] = "C";

            _keyBoard[4, 2] = "D";

            _posX = 0;
            _posY = 2;
        }

        public string GetCode(string[] sequences)
        {
            StringBuilder stringBuilder = new StringBuilder("");
            foreach (var s in sequences)
            {
                stringBuilder.Append(MoveSequence(s));
            }

            return stringBuilder.ToString();
        }

        public string MoveSequence(string sequence)
        {
            var chars = sequence.ToCharArray();

            foreach (var c in chars)
            {
                MoveStep(c);
            }

            return GetCurrentKey();
        }

        private void MoveStep(char c)
        {
            var tmpX = _posX;
            var tmpY = _posY;
            switch (c)
            {
                case 'U':
                {
                    _posY--;
                    break;
                }
                case 'R':
                {
                    _posX++;
                    break;
                }
                case 'D':
                {
                    _posY++;
                    break;
                }
                case 'L':
                {
                    _posX--;
                    break;
                }
            }
            ValidatePositions(tmpX, tmpY);
        }

        private void ValidatePositions(int tmpX, int tmpY)
        {
            var maxX = _keyBoard.GetLength(0) - 1;
            var maxY = _keyBoard.GetLength(1) - 1;

            if (_posX < 0) _posX = 0;
            if (_posY < 0) _posY = 0;
            if (_posX >= maxX) _posX = maxX;
            if (_posY >= maxY) _posY = maxY;

            if (_keyBoard[_posY, _posX] == "")
            {
                _posX = tmpX;
                _posY = tmpY;
            }
        }

        private string GetCurrentKey()
        {
            return _keyBoard[_posY, _posX];
        }
    }
}
