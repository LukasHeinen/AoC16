using System;
using System.Collections.Generic;
using System.Text;
using Day21;
using NUnit.Framework;

namespace Day21Tests
{
    [TestFixture]
    class MoveTests
    {
        [TestCase("abcde", "bcdea", 0, 4)]
        [TestCase("abcde", "acdeb", 1, 4)]
        [TestCase("abcde", "abdce", 2, 3)]
        public void Do_ExampleInput_Outpub(string input, string output, int start, int end)
        {
            var c = input.ToCharArray();
            var rev = new Move(start, end);
            rev.Do(ref c);

            Assert.AreEqual(output, c);
        }
    }
}
