namespace ProblemSet01.Tests
{
    using NUnit.Framework;
    using ProblemSet01.Task_03;

    [TestFixture]
    public class ArraySortingTests
    {
        [Test]
        public void ArraySortingTests_Int_Invariant()
        {
            var transforming = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            ArraySorting.BubbleSort(transforming);
            Assert.AreEqual(expected, transforming);
        }

        [Test]
        public void ArraySortingTests_Int_Reverse()
        {
            var transforming = new int[] { 7, 6, 5, 4, 3, 2, 1 };
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            ArraySorting.BubbleSort(transforming);
            Assert.AreEqual(expected, transforming);
        }

        [Test]
        public void ArraySortingTests_Strings_Invariant()
        {
            var transforming = new string[] { "a", "b", "c", "x", "y", "z" };
            var expected = new string[] { "a", "b", "c", "x", "y", "z" };

            ArraySorting.BubbleSort(transforming);
            Assert.AreEqual(expected, transforming);
        }

        [Test]
        public void ArraySortingTests_Strings_Unordered()
        {
            var transforming = new string[] { "b", "a", "c", "z", "y", "x" };
            var expected = new string[] { "a", "b", "c", "x", "y", "z" };

            ArraySorting.BubbleSort(transforming);
            Assert.AreEqual(expected, transforming);
        }
    }
}
