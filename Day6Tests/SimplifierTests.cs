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
            var strings = "eedadn,drvtee,eandsr,raavrd,atevrs,tsrnev,sdttsa,rasrtv,nssdts,ntnada,svetve,tesnvt,vntsnd,vrdear,dvrsen,enarar".Split(",");
            var convertedStrings = InputTransposer.Convert(strings);

            var simplifiedString = Simplifier.Simplify(convertedStrings);

            Assert.AreEqual("easter", simplifiedString);
        }
    }
}
