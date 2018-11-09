using Core;
using Day2;
using NUnit.Framework;

namespace Day2Tests
{
    [TestFixture]
    public class UnlockerTests
    {
        private Unlocker unlocker;

        [TestCase("", 5)]
        [TestCase("U", 2)]
        [TestCase("R", 6)]
        [TestCase("D", 8)]
        [TestCase("L", 4)]
        public void MoveSequence_SingleStep_ValidResult(string sequence, int expectedResult)
        {
            TestSequence(sequence, expectedResult);
        }

        [TestCase("UR", 3)]
        [TestCase("DL", 7)]
        [TestCase("LD", 7)]
        [TestCase("RL", 5)]
        [TestCase("RD", 9)]
        [TestCase("LU", 1)]
        public void MoveSequence_DoubleStep_ValidResult(string sequence, int expectedResult)
        {
            TestSequence(sequence, expectedResult);
        }

        [Test]
        public void GetCode_TestInput_ValidResult()
        {
            unlocker = new Unlocker();

            var result = unlocker.GetCode(InputFileReader.ReadAllLines("TextInput.txt"));

            Assert.AreEqual("1985", result);
        }

        [Test]
        public void GetCode_TestInput2_ValidResult()
        {
            unlocker = new Unlocker(2);

            var result = unlocker.GetCode(InputFileReader.ReadAllLines("TextInput.txt"));

            Assert.AreEqual("5DB3", result);
        }

        private void TestSequence(string sequence, int expectedResult)
        {
            unlocker = new Unlocker();

            var result = unlocker.MoveSequence(sequence);

            Assert.AreEqual(expectedResult.ToString(), result);
        }
    }
}