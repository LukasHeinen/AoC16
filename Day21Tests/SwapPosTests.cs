using Day21;
using NUnit.Framework;

namespace Day21Tests
{
    [TestFixture]
    public class SwapPosTests
    {
        [TestCase("abcde", "ebcda", 0, 4)]
        [TestCase("abcde", "acbde", 1, 2)]
        [TestCase("abcde", "abedc", 4, 2)]
        [TestCase("abcde", "abcde", 0, 0)]
        [TestCase("abcde", "adcbe", 3, 1)]
        public void Do_ExampleInput_Output(string input, string output, int x, int y)
        {
            var c = input.ToCharArray();
            var swap = new PosSwap(x,y);
            swap.Do(ref c);

            Assert.AreEqual(output, c);
        }
    }
}
