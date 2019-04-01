namespace ProblemSet01.Tests
{
    using NUnit.Framework;
    using ProblemSet01.Task_04;

    [TestFixture]
    public class SpiralWalkTests
    {
        [Test]
        public void SpiralWalkTests_Regular()
        {
            var matrix = new int[,]
            {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 },
                { 21, 22, 23, 24, 25 }
            };

            var expected = new int[]
            {
                13, 14, 19, 18, 17,
                12, 7, 8, 9, 10, 15,
                20, 25, 24, 23, 22,
                21, 16, 11, 6,
                1, 2, 3, 4, 5
            };

            var result = SpiralWalk.WalkThroughMatrix(matrix);
            Assert.AreEqual(expected, result);
        }
    }
}
