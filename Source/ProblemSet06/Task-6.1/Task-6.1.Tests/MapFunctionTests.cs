namespace ProblemSet06.Task01.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class MapFunctionTests
    {
        [Test]
        public void PowerOfTwoForDoubles()
        {
            var sut = new List<int>() { 11, 22, 33, 44, 55 };
            var expected = new List<int>() { 121, 484, 1089, 1936, 3025 };
            int PowerOfTwo(int x) => x * x;

            var actual = HigherOrderFunctionsForList<int>.Map(sut, PowerOfTwo);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateFibonacciForIntegers()
        {
            var sut = new List<uint>() { 0, 1, 2, 3, 4 };
            uint Fib(uint x) => x > 1 ? Fib(x - 1) + Fib(x - 2) : x;
            var expected = new List<uint>() { 0, 1, 1, 2, 3 };

            var actual = HigherOrderFunctionsForList<uint>.Map(sut, Fib);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddRoundBrackets()
        {
            var sut = new List<string>() { "abc", "cat", "dog", "elephant in the room", "Pi = 3.14.." };
            string AddBrackets(string x) => $"({x})";
            var expected = new List<string>() { "(abc)", "(cat)", "(dog)", "(elephant in the room)", "(Pi = 3.14..)" };

            var actual = HigherOrderFunctionsForList<string>.Map(sut, AddBrackets);
            Assert.AreEqual(expected, actual);
        }
    }
}
