using Day18;
using NUnit.Framework;

namespace Day18Tests
{
    [TestFixture]
    public class RowGeneratorTests
    {
        [TestCase("..^^.", ".^^^^")]
        [TestCase(".^^^^", "^^..^")]
        [TestCase(".^^.^.^^^^", "^^^...^..^")]
        public void GenerateRow_ExampeInput_ExpectedRow(string input, string expectedOutput)
        {
            var newRow = RowGenerator.Generate(input);
            Assert.AreEqual(expectedOutput, newRow);
        }
    }
}
