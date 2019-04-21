namespace ProblemSet06.Task01.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class FilterFunctionTests
    {
        [Test]
        public static void IsPositiveElements()
        {
            var sut = new List<double> { 2.1, -135.0, -3.2, 500.4, 40.5 };
            bool IsPositive(double x) => x > 0;
            var expected = new List<double> { 2.1, 500.4, 40.5 };

            var actual = HigherOrderFunctionsForList<double>.Filter(sut, IsPositive);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void DivisibleByThree()
        {
            var sut = new List<int> { 21, -121, -39, 35, 498 };
            bool IsPositive(int x) => x % 3 == 0;
            var expected = new List<int> { 21, -39, 498 };

            var actual = HigherOrderFunctionsForList<int>.Filter(sut, IsPositive);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void AbsoluteValueMoreThanHundred()
        {
            var sut = new List<double> { 20.1, -121.333, -33.9, -435.0, 498.88 };
            bool MoreThanHundred(double x) => Math.Abs(x) > 100.0;
            var expected = new List<double> { -121.333, -435.0, 498.88 };

            var actual = HigherOrderFunctionsForList<double>.Filter(sut, MoreThanHundred);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void OnlyUpperCaseLetters()
        {
            var sut = new List<string> { "KITTEN", "A BUG", "wale", "Computer Science", string.Empty };
            bool IsUpperCase(string v) => string.IsNullOrEmpty(v) || v.ToUpperInvariant() == v;
            var expected = new List<string> { "KITTEN", "A BUG", string.Empty };

            var actual = HigherOrderFunctionsForList<string>.Filter(sut, IsUpperCase);
            Assert.AreEqual(expected, actual);
        }
    }
}
