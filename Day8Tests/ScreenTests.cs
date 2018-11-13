using System;
using Day8;
using NUnit.Framework;

namespace Day8Tests
{
    [TestFixture]
    public class ScreenTests
    {
        [Test]
        public void ExecuteCommand()
        {
            var screen = new Screen(3,7);

            screen.ExecuteCommand("rect 3x2");
            var res = screen.GetScreen();
            Assert.AreEqual("###....", res[0]);
            Assert.AreEqual("###....", res[1]);
            Assert.AreEqual(".......", res[2]);

            screen.ExecuteCommand("rotate column x=1 by 1");
            res = screen.GetScreen();
            Assert.AreEqual("#.#....", res[0]);
            Assert.AreEqual("###....", res[1]);
            Assert.AreEqual(".#.....", res[2]);

            screen.ExecuteCommand("rotate row y=0 by 4");
            res = screen.GetScreen();
            Assert.AreEqual("....#.#", res[0]);
            Assert.AreEqual("###....", res[1]);
            Assert.AreEqual(".#.....", res[2]);

            screen.ExecuteCommand("rotate column x=1 by 1");
            res = screen.GetScreen();
            Assert.AreEqual(".#..#.#", res[0]);
            Assert.AreEqual("#.#....", res[1]);
            Assert.AreEqual(".#.....", res[2]);
            Assert.AreEqual(6, screen.GetCount());
        }
    }
}