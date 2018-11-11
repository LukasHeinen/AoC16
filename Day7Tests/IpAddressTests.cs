using System;
using Day7;
using NUnit.Framework;

namespace Day7Tests
{
    [TestFixture]
    public class IpAddressTests
    {
        [TestCase("abba[mnop]qrst", true)]
        [TestCase("abcd[bddb]xyyx", false)]
        [TestCase("aaaa[qwer]tyui", false)]
        [TestCase("ioxxoj[asdfgh]zxcvbn", true)]
        public void SupportsTls_ExampleInput_ExpectedResult(string input, bool expectedValidity)
        {
            var address = new IpAddress(input);

            var validity = address.SupportsTls();

            Assert.AreEqual(expectedValidity, validity);
        }

        [TestCase("aba[bab]xyz", true)]
        [TestCase("xyx[xyx]xyx", false)]
        [TestCase("aaa[kek]eke", true)]
        [TestCase("zazbz[bzb]cdb", true)]
        public void SupportsSsl_ExampleInput_ExpectedResult(string input, bool expectedValidity)
        {
            var address = new IpAddress(input);

            var validity = address.SupportsSsl();

            Assert.AreEqual(expectedValidity, validity);
        }
    }
}
