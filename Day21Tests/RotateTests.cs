using Day21;
using NUnit.Framework;

namespace Day21Tests
{
    [TestFixture]
    public class RotateTests
    {
        [TestCase("abcde", "bcdea", -1, 0)]
        [TestCase("abcde", "eabcd", 1, 0)]
        [TestCase("abcde", "bcdea", 4, 0)]
        [TestCase("abcde", "eabcd", 'a', 'a')]
        [TestCase("abdec", "ecabd", 'b', 'b')]
        [TestCase("ecabd", "decab", 'd', 'd')]
        public void Do_ExampleInput_Output(string input, string output, int start, int end)
        {
            var c = input.ToCharArray();
            var rev = new Rotate(start, end, false);
            rev.Do(ref c);

            Assert.AreEqual(output, c);
        }

        [TestCase("abcde", "bcdea", -1, 0)]
        [TestCase("abcde", "eabcd", 1, 0)]
        [TestCase("abcde", "bcdea", 4, 0)]
        [TestCase("habcdefg", "abcdefgh", 'a', 'a')]
        [TestCase("ghabcdef", "abcdefgh", 'b', 'b')]
        [TestCase("fghabcde", "abcdefgh", 'c', 'c')]
        [TestCase("efghabcd", "abcdefgh", 'd', 'd')]
        [TestCase("cdefghab", "abcdefgh", 'e', 'e')]
        [TestCase("bcdefgha", "abcdefgh", 'f', 'f')]
        [TestCase("abcdefgh", "abcdefgh", 'g', 'g')]
        [TestCase("habcdefg", "abcdefgh", 'h', 'h')]
        public void DoReverse_ExampleInput_Output(string input, string output, int start, int end)
        {
            var c = input.ToCharArray();
            var rev = new Rotate(start, end, true);
            rev.Do(ref c);

            Assert.AreEqual(output, c);
        }
    }
}
