using System;
using Day17;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Day17Tests
{
    [TestFixture]
    public class PathfinderTests
    {
        [TestCase("hijkl", "ced9")]
        [TestCase("hijklD", "f2bc")]
        [TestCase("hijklDR", "5745")]
        [TestCase("hijklDU", "528e")]
        public void ProduceHash_ExampleHash_ExpectedResult(string hash, string expectedHash)
        {
            var pathfinder = new Pathfinder(3,3);

            var nextHash = pathfinder.ProduceHash(hash);

            Assert.AreEqual(expectedHash, nextHash);
        }

        [TestCase(new[] { 0, 0 }, "hijklDR", null)]
        [TestCase(new[] { 0, 0 }, "hijkl", new[]{'D'})]
        [TestCase(new[] { 1, 0 }, "hijklDU", new[] { 'R' })]
        [TestCase(new[] { 0, 1 }, "hijklD", new[] { 'U','R' })]

        public void GetValidDirections_Exmaples_ExpectedResultsAsArray(int[] startingPos, string hash, char[] expectedDirections)
        {
            var pathfinder = new Pathfinder(3, 3);
            var initalState = new Tuple<int[], string>(startingPos, hash);

            var dirs = pathfinder.GetValidDirections(initalState);
            if (expectedDirections!=null) Array.Sort(expectedDirections);
            Assert.AreEqual(expectedDirections, dirs);
        }

        [TestCase(new[] { 0, 0 },"hijkl", 'D', new []{ 0, 1 }, "hijklD")]
        [TestCase(new[] { 0, 1 }, "hijklD", 'U', new[] { 0, 0 }, "hijklDU")]
        public void ExecuteTransition(int[] startingPos, string hash, char dir, int[] expectedPos, string expectedHash)
        {
            var pathfinder = new Pathfinder(3, 3);
            var initialState = new Tuple<int[], string>(startingPos, hash);

            var newState = pathfinder.ExecuteTransition(initialState, dir);

            var expectedState = new Tuple<int[], string>(expectedPos, expectedHash);
            Assert.AreEqual(expectedState, newState);
        }
    }
}
