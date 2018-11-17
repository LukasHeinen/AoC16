using System;
using System.Collections.Generic;
using System.Text;
using Day11.data;
using NUnit.Framework;

namespace Day11Tests
{
    [TestFixture]
    public class StateTests
    {
        [TestCase("BM,AM", "BG,AG", "00 AM,BM1 AG,BG")]
        [TestCase("CM,AM", "BG,AG", "00 AM,CM1 AG,BG")]
        [TestCase("AM,BM", "AG,BG", "00 AM,BM1 AG,BG")]
        public void ToString_InputFloors_SerializedState(string floor1, string floor2, string expectedResult)
        {
            var state = new State(new[] { floor1, floor2 });

            Assert.AreEqual(expectedResult, state.ToString());
        }

        [TestCase("AM,BM", "AG,BG", "CG", "CM", "00,10,13,2")]
        [TestCase("CM,BM", "CG,BG", "AG", "AM", "00,10,13,2")]
        [TestCase("AM", "AG,BG", "CG,BM", "CM", "00,12,13,2")]
        public void GeneratePattern_State_Pattern(string floor1, string floor2, string floor3, string floor4, string expectedResult)
        {
            var state = new State(new[] { floor1, floor2, floor3, floor4 });

            Assert.AreEqual(expectedResult, state.GeneratePattern());

        }

        [Test, TestCaseSource("TestStates")]
        public void ExecuteValidTransaction_State_NewState(Tuple<State, Transaction, State> input)
        {
            var executedState = input.Item1.ExecuteTransaction(input.Item2);

            Assert.AreEqual(input.Item3.ToString(), executedState.ToString());
        }

        public static Tuple<State,Transaction, State>[] TestStates()
        {
            var cases = new List<Tuple<State, Transaction, State>>();

            var input1 = new State(new [] {"AM,BM",""});
            var transaction1 = new Transaction() { Direction = 1, Objects = new [] { "AM" }};
            var output1= new State(new[] { "BM","AM" },1);

            var input2 = new State(new[] { "AM,BM", "CG,AG,BG" });
            var transaction2 = new Transaction() { Direction = 1, Objects = new[] { "AM","BM" }};
            var output2 = new State(new[] { "", "AM,BM,CG,AG,BG" },1);

            var input3 = new State(new[] { "AG,BG", "CG,AM,BM" },1);
            var transaction3 = new Transaction() { Direction = -1, Objects = new[] { "AM", "BM" }};
            var output3 = new State(new[] { "AM,BM,AG,BG", "CG" },0);

            cases.Add(new Tuple<State, Transaction, State>(input1,transaction1,output1));
            cases.Add(new Tuple<State, Transaction, State>(input2, transaction2, output2));
            cases.Add(new Tuple<State, Transaction, State>(input3, transaction3, output3));

            return cases.ToArray();
        }
    }
}
