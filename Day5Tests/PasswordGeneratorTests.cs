using System;
using Day5;
using NUnit.Framework;

namespace Day5Tests
{
    [TestFixture]
    public class PasswordGeneratorTests
    {
        private PasswordGenerator _passwordGenerator;

        [SetUp]
        public void Init()
        {
            _passwordGenerator = new PasswordGenerator();
        }

        [TestCase("abc3231929", true)]
        [TestCase("abc5017308", true)]
        [TestCase("abc5278568", true)]
        public void Validate_ValidIndex_True(string input, bool expectedResult)
        {
            var success = _passwordGenerator.HasValidHash(input, out var hash);

            Assert.AreEqual(expectedResult, success);
        }

        // Test take quite a while
        /*
        [Test]
        public void ComputeHash_ExampleInput_ExpectedPassword()
        {
            var input = "abc";

            var password = _passwordGenerator.ComputePassword(input);

            Assert.AreEqual("18f47a30", password);
        }
        */

        // Test take quite a while
        /*
        [Test]
        public void ComputeHash2_ExampleInput_ExpectedPassword()
        {
            var input = "abc";

            var password = _passwordGenerator.ComputePassword2(input);

            Assert.AreEqual("05ace8e3", password);
        }
        */
    }
}
