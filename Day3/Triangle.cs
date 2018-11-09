using System;

namespace Day3
{
    public class Triangle
    {
        private readonly int[] _sides;

        public Triangle(int[] sides)
        {
            _sides = sides;
        }

        public bool IsValid()
        {
            Array.Sort(_sides);
            return (SumOfSmallest() > _sides[_sides.Length - 1]);

        }

        private int SumOfSmallest()
        {
            var sum = 0;
            for (var i = 0; i < _sides.Length-1; i++)
            {
                sum += _sides[i];
            }

            return sum;
        }
    }
}
