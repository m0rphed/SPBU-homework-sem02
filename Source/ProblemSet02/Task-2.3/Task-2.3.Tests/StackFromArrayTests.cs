namespace ProblemSet02.Tests.Task03
{
    using NUnit.Framework;
    using ProblemSet02.Task03;

    [TestFixture]
    public class StackFromArrayTests
    {
        [Test]
        public void TestIntOrder()
        {
            var s = new StackFromArray<int>(100);

            s.Push(1);
            s.Push(2);
            s.Push(3);

            Assert.AreEqual(3, s.Count);
            Assert.AreEqual(3, s.Pop());
            Assert.AreEqual(2, s.Pop());
            Assert.AreEqual(1, s.Pop());
            Assert.AreEqual(0, s.Count);
        }
    }
}
