namespace ProblemSet03.Tests.Task01
{
    using NUnit.Framework;
    using ProblemSet03.Task01;

    [TestFixture]
    public class StackFromArrayTests
    {
        private StackFromArray<int> _sut;

        [SetUp]
        public void Initialize()
        {
            _sut = new StackFromArray<int>(100);
        }

        [Test]
        public void TestIntOrder()
        {
            _sut.Push(1);
            _sut.Push(2);
            _sut.Push(3);

            Assert.AreEqual(3, _sut.Count);
            Assert.AreEqual(3, _sut.Pop());
            Assert.AreEqual(2, _sut.Pop());
            Assert.AreEqual(1, _sut.Pop());
            Assert.AreEqual(0, _sut.Count);
        }

        [Test]
        public void TestStackOnArrayExpansion()
        {
            _sut.Push(1);
            _sut.Push(2);
            _sut.Push(3);

            Assert.AreEqual(3, _sut.Count);
            Assert.AreEqual(3, _sut.Pop());
            Assert.AreEqual(2, _sut.Pop());
            Assert.AreEqual(1, _sut.Pop());
            Assert.AreEqual(0, _sut.Count);
        }
    }
}
