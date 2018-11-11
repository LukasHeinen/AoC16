using Day4;
using NUnit.Framework;

namespace Day4Tests
{
    [TestFixture]
    public class RoomTests
    {
        [TestCase("aaaaa-bbb-z-y-x-123[abxyz]", "aaaaabbbzyx", 123, "abxyz")]
        [TestCase("a-b-c-d-e-f-g-h-987[abcde]", "abcdefgh", 987, "abcde")]
        [TestCase("not-a-real-room-404[oarel]", "notarealroom", 404, "oarel")]
        [TestCase("totally-real-room-200[decoy]", "totallyrealroom", 200, "decoy")]
        public void Room_ExampleInput_CorrectCreation(string input, string expectedName, int expectedSectorId, string expectedChecksum)
        {
            var r = new Room(input);

            Assert.AreEqual(expectedName, r.GetName());
            Assert.AreEqual(expectedChecksum, r.GetChecksum());
            Assert.AreEqual(expectedSectorId, r.GetSectorId());
        }

        [TestCase("aaaaa-bbb-z-y-x-123[abxyz]")]
        [TestCase("a-b-c-d-e-f-g-h-987[abcde]")]
        [TestCase("not-a-real-room-404[oarel]")]
        public void IsValid_ValidRooms_True(string input)
        {
            var r= new Room(input);

            Assert.AreEqual(true, r.IsValid());
        }

        [TestCase("totally-real-room-200[decoy]")]
        public void IsValid_InvalidRooms_False(string input)
        {
            var r = new Room(input);

            Assert.AreEqual(false, r.IsValid());
        }

        [Test]
        public void GetEncryptedName_Example_CorrecResult()
        {
            var r = new Room("qzmt-zixmtkozy-ivhz-343[xyz]");

            var encryptedName = r.GetEncryptedName();

            Assert.AreEqual("very encrypted name", encryptedName);
        }
    }
}
