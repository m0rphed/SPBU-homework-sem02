namespace ProblemSet03.Tests.Task01
{
    using System;
    using NUnit.Framework;
    using ProblemSet03.Task01;

    [TestFixture]
    public class StackFromListTests
    {
        [Test]
        public void TestIntOrder()
        {
            var s = new StackFromList<int>();

            s.Push(1);
            s.Push(2);
            s.Push(3);

            Assert.AreEqual(3, s.Count);
            Assert.AreEqual(3, s.Pop());
            Assert.AreEqual(2, s.Pop());
            Assert.AreEqual(1, s.Pop());
            Assert.AreEqual(0, s.Count);
        }

        [Test]
        public void ErrorOnEmptyStack()
        {
            Assert.Throws<Exception>(() =>
            {
                StackFromList<int> sut = new StackFromList<int>();
                sut.Pop();
            }, "Could not pop from empty stack");
        }
    }
}
