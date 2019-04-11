namespace ProblemSet03.Tests.Task01
{
    using System;
    using NUnit.Framework;
    using ProblemSet03.Task01;

    [TestFixtureSource(typeof(StackImplementationsTests.MyFixtureData), "FixtureParms")]
    public class StackImplementationsTests
    {
        /// <summary>
        /// Provides two different implementations of <see cref="IStack{T}"/>.
        /// </summary>
        public static class MyFixtureData
        {
            private static readonly Func<IStack<string>> buildFromArray = () => new StackFromArray<string>(100);
            private static readonly Func<IStack<string>> buildFromList = () => new StackFromList<string>();

            public static object[] FixtureParms => new object[]
            {
            new object[] { buildFromArray, "From array" },
            new object[] { buildFromList, "From list" }
            };
        }

        private readonly Func<IStack<string>> _createStack;

        public StackImplementationsTests(Func<IStack<string>> stack, string testName)
        {
            _createStack = stack;
        }

        [Test]
        public void TestElementsInOrder()
        {
            var sut = _createStack();
            sut.Push("1");
            sut.Push("2");
            sut.Push("3");

            Assert.AreEqual(3, sut.Count);
            Assert.AreEqual("3", sut.Pop());
            Assert.AreEqual("2", sut.Pop());
            Assert.AreEqual("1", sut.Pop());
            Assert.AreEqual(0, sut.Count);
        }

        [Test]
        public void ErrorOnEmptyStack()
        {
            Assert.Throws<ApplicationException>(() =>
            {
                var sut = _createStack();
                sut.Pop();
            }, "Could not pop from empty stack");
        }
    }
}
