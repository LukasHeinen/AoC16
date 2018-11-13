using System;
using Day9;
using NUnit.Framework;


namespace Day9Tests
{
    [TestFixture]
    public class CodeTests
    {
        [TestCase("ADVENT", 6)]
        [TestCase("A(1x5)BC", 7)]
        [TestCase("(3x3)XYZ", 9)]
        [TestCase("A(2x2)BCD(2x2)EFG", 11)]
        [TestCase("(6x1)(1x3)A", 6)]
        [TestCase("X(8x2)(3x3)ABCY", 18)]
        public void DecompressAndCount_Examples_CorrectCount(string input, long expectedCount)
        {
            var code = new Code(input);

            var res = code.DecompressAndCount(out var dummy);

            Assert.AreEqual(expectedCount, res);
        }

        [TestCase("ADVENT", 6)]
        [TestCase("(3x3)XYZ", 9)]
        [TestCase("X(8x2)(3x3)ABCY", 20)]
        [TestCase("(27x12)(20x12)(13x14)(7x10)(1x12)A", 241920)]
        [TestCase("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN", 445)]
        public void DecompressAndCount2_Examples_CorrectCount(string input, long expectedCount)
        {
            var code = new Code(input);

            var res = code.DecompressAndCount2();

            Assert.AreEqual(expectedCount, res);
        }
    }
}

