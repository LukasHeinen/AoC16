using System;
using Day11;
using Day11.data;
using NUnit.Framework;

namespace Day11Tests
{
    [TestFixture]
    public class FloorTests
    {
        [TestCase("AM,BM,CM", true)]
        [TestCase("AM", true)]
        [TestCase("AG", true)]
        [TestCase("AG,BG,AM", true)]
        [TestCase("AM,AG,CM,CG", true)]
        [TestCase("AM,AG,CM,CG", true)]
        [TestCase("AM,BG,CM,CG", false)]
        [TestCase("AM,AG,CM", false)]
        [TestCase("AM,AG,CM,BG", false)]

        public void IsValid_TestCaseInput_ExpectedTestCaseOutput(string input, bool expectedOutput)
        {
            var floor = new Floor(input.Split(","));

            var isvalid = floor.IsValid();

            Assert.AreEqual(expectedOutput, isvalid);
        }
    }
}
