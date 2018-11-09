using NetCore;
using NUnit.Framework;

namespace Day1Tests
{
    [TestFixture]
    public class Tests
    {
        private PathCalculator _pathCalculator;
        
        [Test]
        public void Run1()
        {
            _pathCalculator = new PathCalculator("R2, L3");

            var res = _pathCalculator.run();

            Assert.AreEqual(5, res);
        }

        [Test]
        public void Run2()
        {
            _pathCalculator = new PathCalculator("R2, R2, R2");

            var res = _pathCalculator.run();

            Assert.AreEqual(2, res);
        }

        [Test]
        public void Run3()
        {
            _pathCalculator = new PathCalculator("R5, L5, R5, R3");

            var res = _pathCalculator.run();

            Assert.AreEqual(12, res);
        }

        [Test]
        public void Run4()
        {
            _pathCalculator = new PathCalculator("R8, R4, R4, R8");

            var res = _pathCalculator.run();

            Assert.AreEqual(4, res);
        }
    }
}
