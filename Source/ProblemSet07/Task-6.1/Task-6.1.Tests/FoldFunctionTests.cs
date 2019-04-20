namespace ProblemSet06.Task01.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class FoldFunctionTests
    {
        [Test]
        public void SumTheSequence()
        {
            var sut = new List<int>() { 1, 2, 3, 5, 8 };
            int SequenceSum(int acc, int elem) => acc + elem;

            var actual = HigherOrderFunctionsForList<int>.Fold(sut, 0, SequenceSum);
            Assert.AreEqual(19, actual);
        }

        [Test]
        public void MultiplyTheSequence()
        {
            var sut = new List<double>() { 1.1, 2.2, 3.3, 4.4, 5.5 };
            double SequenceProduct(double acc, double elem) => acc * elem;

            var actual = HigherOrderFunctionsForList<double>.Fold(sut, 1, SequenceProduct);
            Assert.AreEqual(193.2612, actual, 0.0001);
        }

        [Test]
        public void ConcatenateStringsUsingFold()
        {
            var sut = new List<string>() { "Наши", "Боги", "Под", "Водой!" };
            string SequenceProduct(string acc, string elem) => $"{acc}{elem}";

            var expected = string.Join(string.Empty, sut);
            var actual = HigherOrderFunctionsForList<string>.Fold(sut, string.Empty, SequenceProduct);

            Assert.AreEqual(expected, actual);
        }
    }
}
