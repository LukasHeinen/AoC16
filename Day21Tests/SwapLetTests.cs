using Day21;
using NUnit.Framework;

namespace Day21Tests
{
    [TestFixture]
    public class SwapLetTests
    {
        [TestCase("abcde", "ebcda", 'a', 'e')]
        [TestCase("abcde", "acbde", 'b', 'c')]
        [TestCase("abcde", "abedc", 'e', 'c')]
        [TestCase("abcde", "abcde", 'a', 'a')]
        [TestCase("abcde", "adcbe", 'd', 'b')]
        public void Do_ExampleInput_Output(string input, string output, int x, int y)
        {
            var c = input.ToCharArray();
            var swap = new LetterSwap(x,y);
            swap.Do(ref c);

            Assert.AreEqual(output, c);
        }
    }
}
