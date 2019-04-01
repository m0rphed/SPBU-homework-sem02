namespace ProblemSet01.Tests
{
    using NUnit.Framework;
    using ProblemSet01.Task_05;

    [TestFixture]
    public class ColumnsSortingTests
    {
        [Test]
        public void ColumnsSortingInvariant()
        {
            var transforming = new int[,]
            {
                { 1, 2, 3 },
                { 3, 2, 1 },
                { 4, 5, 6 }
            };

            var expected = new int[,]
            {
                { 1, 2, 3 },
                { 3, 2, 1 },
                { 4, 5, 6 }
            };

            ColumnsSorting.MatrixSort(transforming);
            Assert.AreEqual(expected, transforming);
        }

        [Test]
        public void ColumnsSortingReverse()
        {
            var transforming = new int[,]
            {
                { 3, 2, 1 },
                { 3, 2, 1 },
                { 4, 5, 6 }
            };

            var expected = new int[,]
            {
                { 1, 2, 3 },
                { 1, 2, 3 },
                { 6, 5, 4 }
            };

            ColumnsSorting.MatrixSort(transforming);
            Assert.AreEqual(expected, transforming);
        }
    }
}
