using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace Day17
{
    public class Pathfinder
    {
        private readonly HashGenerator _hashGen;
        private readonly int _maxX;
        private readonly int _maxY;

        public Pathfinder(int maxX, int maxY)
        {
            _hashGen = new HashGenerator();
            _maxX = maxX;
            _maxY = maxY;
        }
        public string ProduceHash(string input)
        {
            var fullHash = _hashGen.ComputeFullHash(input);
            return fullHash.Substring(0, 4).ToLower();
        }

        public char[] GetValidDirections(Tuple<int[], string> state)
        {
            var listValidForPosition = new List<char>();
            var listValidForHash = new List<char>();

            var posX = state.Item1[0];
            var posY = state.Item1[1];

            var newHash = ProduceHash(state.Item2);

            var h0 = newHash[0];
            var h1 = newHash[1];
            var h2 = newHash[2];
            var h3 = newHash[3];

            if (posX > 0)
            {
                listValidForPosition.Add('L');
            }
            if (posX < _maxX)
            {
                listValidForPosition.Add('R');
            }
            if (posY > 0)
            {
                listValidForPosition.Add('U');
            }
            if (posY < _maxY)
            {
                listValidForPosition.Add('D');
            }

            if (h0 == 'b' || h0 == 'c' || h0 == 'd' || h0 == 'e' || h0 == 'f') listValidForHash.Add('U');
            if (h1 == 'b' || h1 == 'c' || h1 == 'd' || h1 == 'e' || h1 == 'f') listValidForHash.Add('D');
            if (h2 == 'b' || h2 == 'c' || h2 == 'd' || h2 == 'e' || h2 == 'f') listValidForHash.Add('L');
            if (h3 == 'b' || h3 == 'c' || h3 == 'd' || h3 == 'e' || h3 == 'f') listValidForHash.Add('R');

            var result = listValidForPosition.Intersect(listValidForHash).ToArray();
            Array.Sort(result);
            if (!result.Any()) return null;
            return result;
        }

        public Tuple<int[], string> ExecuteTransition(Tuple<int[], string> initialState, char direction)
        {
            var posX = initialState.Item1[0];
            var posY = initialState.Item1[1];
            var dir = direction;

            var newHash = initialState.Item2 + dir;

            switch (dir)
            {
                case 'U':
                {
                    posY--;
                    break;
                }
                case 'D':
                {
                    posY++;
                    break;
                }
                case 'R':
                {
                    posX++;
                    break;
                }
                case 'L':
                {
                    posX--;
                    break;
                }
            }

            return new Tuple<int[], string>(new [] {posX, posY}, newHash);
        }
    }
}
