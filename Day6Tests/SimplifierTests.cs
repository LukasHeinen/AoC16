using System;
using Core;
using Day6;
using NUnit.Framework;

namespace Day6Tests
{
    [TestFixture]
    public class SimplifierTests
    {
        [Test]
        public void Simplify_TestStringArray_ExpectedResultString()
        {
            var strings = InputFileReader.ReadAllLines("TestInput.txt");
            var convertedStrings = InputConverter.Convert(strings);

            var simplifiedString = Simplifier.Simplify(convertedStrings);

            Assert.AreEqual("easter", simplifiedString);
        }
    }
}
