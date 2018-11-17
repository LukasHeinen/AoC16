using Day11;
using Day11.data;
using NUnit.Framework;

namespace Day11Tests
{
    [TestFixture]
    public class SearchEngineTests
    {
        [Test]
        public void Run_ExampleInput_11()
        {
            var initialState = new State(new [] {"HM,LM","HG", "LG", ""});
            
            var searcher = new SearchEngine(initialState);
            var res = searcher.Run(new State(new[] { "", "", "", "HM,LM,HG,LG" },3));

            Assert.AreEqual(11, res);
        }
    }
}
