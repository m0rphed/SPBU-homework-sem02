namespace ProblemSet02.Task01.Tests
{
    using System;
    using NUnit.Framework;
    using ProblemSet02.Task01;

    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void TestSimpleExample()
        {
            const int length = 10;
            var sut = new LinkedList();

            // transform empty list to:
            // [1]->[2]->[3]->[4]->[5]->[6]->[7]->[8]->[9]->[10]
            for (int i = 0; i < length; ++i)
            {
                sut.AddValueOnPosition(i + 1, i);
            }

            // expected lenght: 10
            Assert.AreEqual(length, sut.Length);
        }

        [Test]
        public void AddThenDeleteElements()
        {
            var sut = new LinkedList();

            // list : [0]->[10]->[20]->[30]
            sut.AddValueOnPosition(0, 0);
            sut.AddValueOnPosition(10, 1);
            sut.AddValueOnPosition(20, 2);
            sut.AddValueOnPosition(30, 3);

            // list : [10]->[20]->[30], will be removed: [0] on position 0
            sut.RemoveElementByPosition(0);

            // list : [10]->[30], will be removed: [20] on position 1
            sut.RemoveElementByPosition(1);

            Assert.AreEqual(10, sut.GetValueByPosition(0));
            Assert.AreEqual(30, sut.GetValueByPosition(1));
        }

        [Test]
        public void ThrowExceptionOnRemoveFromEmptyList()
        {
            Assert.Throws<EmptyListException>(
                () =>
            {
                var sut = new LinkedList();
                sut.RemoveElementByPosition(0);
            }, "Could not delete from empty list");
        }

        [Test]
        public void ThrowExceptionOnRemoveOutOfRange()
        {
            Assert.Throws<IndexOutOfRangeException>(
                () =>
            {
                var sut = new LinkedList();
                sut.AddValueOnPosition(1, 0);
                sut.AddValueOnPosition(2, 1);

                sut.RemoveElementByPosition(3);
            }, "Incorrect position");
        }

        [Test]
        public void ThrowIndexExceptionToAddOutOfRange()
        {
            Assert.Throws<IndexOutOfRangeException>(
                () =>
            {
                var sut = new LinkedList();
                sut.AddValueOnPosition(1337, 9000);
            }, "Incorrect position");
        }

        [Test]
        public void TestIsEmptyMethod()
        {
            var sut = new LinkedList();
            Assert.IsTrue(sut.IsEmpty());

            // add some elements
            sut.AddValueOnPosition(1, 0);
            sut.AddValueOnPosition(2, 0);
            sut.AddValueOnPosition(3, 0);

            Assert.IsFalse(sut.IsEmpty());

            // remove all
            while (!sut.IsEmpty())
            {
                sut.RemoveElementByPosition(0);
            }

            Assert.IsTrue(sut.IsEmpty());
        }
    }
}
