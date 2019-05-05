namespace ProblemSet04.Task02.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CustomListTests
    {
        private CustomList<int> _sut;

        [SetUp]
        public void Initialize()
        {
            _sut = new CustomList<int>();
        }

        [Test]
        public void TestSimpleExample()
        {
            const int length = 10;

            // transform empty list to:
            // [1]->[2]->[3]->[4]->[5]->[6]->[7]->[8]->[9]->[10]
            for (int i = 0; i < length; ++i)
            {
                _sut.AddValueOnPosition(i + 1, i);
            }

            // expected lenght: 10
            Assert.AreEqual(length, _sut.Length);
        }

        [Test]
        public void AddThenDeleteElements()
        {
            // list : [0]->[10]->[20]->[30]
            _sut.AddValueOnPosition(0, 0);
            _sut.AddValueOnPosition(10, 1);
            _sut.AddValueOnPosition(20, 2);
            _sut.AddValueOnPosition(30, 3);

            // list : [10]->[20]->[30], will be removed: [0] on position 0
            _sut.RemoveElementByPosition(0);

            // list : [10]->[30], will be removed: [20] on position 1
            _sut.RemoveElementByPosition(1);

            Assert.AreEqual(10, _sut.GetValueByPosition(0));
            Assert.AreEqual(30, _sut.GetValueByPosition(1));
        }

        [Test]
        public void ThrowExceptionOnRemoveFromEmptyList()
        {
            Assert.Throws<EmptyListException>(
                () =>
                {
                    _sut.RemoveElementByPosition(0);
                }, "Could not delete from empty list");
        }

        [Test]
        public void ThrowExceptionOnRemoveOutOfRange()
        {
            Assert.Throws<IndexOutOfRangeException>(
                () =>
                {
                    _sut.AddValueOnPosition(1, 0);
                    _sut.AddValueOnPosition(2, 1);

                    _sut.RemoveElementByPosition(3);
                }, "Incorrect position");
        }

        [Test]
        public void ThrowIndexExceptionToAddOutOfRange()
        {
            Assert.Throws<IndexOutOfRangeException>(
                () =>
                {
                    _sut.AddValueOnPosition(1337, 9000);
                }, "Incorrect position");
        }

        [Test]
        public void TestIsEmptyMethod()
        {
            Assert.IsTrue(_sut.IsEmpty());

            // add some elements
            _sut.AddValueOnPosition(1, 0);
            _sut.AddValueOnPosition(2, 0);
            _sut.AddValueOnPosition(3, 0);

            Assert.IsFalse(_sut.IsEmpty());

            // remove all
            while (!_sut.IsEmpty())
            {
                _sut.RemoveElementByPosition(0);
            }

            Assert.IsTrue(_sut.IsEmpty());
        }
    }
}
