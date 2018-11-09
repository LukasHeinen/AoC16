using Day3;
using NUnit.Framework;

namespace Day3Tests
{
    [TestFixture]
    public class TriangleTests
    {
        [TestCase(1,2,2)]
        [TestCase(2, 2, 1)]
        [TestCase(5, 4, 8)]
        [TestCase(5, 5, 9)]
        public void IsValid_ValidTriangle_True(int s1, int s2, int s3)
        {
            var i = new int[] {s1, s2, s3};
            var t = new Triangle(i);

            Assert.AreEqual(true, t.IsValid());
        }

        [TestCase(0, 5, 9)]
        [TestCase(1, 2, 3)]
        [TestCase(5, 2, 7)]
        public void IsValid_InvalidTriangle_False(int s1, int s2, int s3)
        {
            var i = new int[] { s1, s2, s3 };
            var t = new Triangle(i);

            Assert.AreEqual(false, t.IsValid());
        }
    }
}
