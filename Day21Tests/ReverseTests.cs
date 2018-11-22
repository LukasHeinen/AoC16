using Day21;
using NUnit.Framework;

namespace Day21Tests
{
    [TestFixture]
    public class ReverseTests
    {
        [TestCase("edcba", "abcde",0,4)]
        [TestCase("edcba", "eabcd", 1, 4)]
        [TestCase("edcba", "edcab", 3, 4)]
        public void Do_ExampleInput_Outpub(string input, string output, int start, int end)
        {
            var c = input.ToCharArray();
            var rev = new Reverse(start, end);
            rev.Do(ref c);

            Assert.AreEqual(output, c);
        }
    }
}
