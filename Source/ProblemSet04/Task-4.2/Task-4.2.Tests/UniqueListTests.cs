namespace ProblemSet04.Task02.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class UniqueListTests
    {
        private UniqueList<int> _sut;

        [SetUp]
        public void Initialize()
        {
            _sut = new UniqueList<int>();
        }

        [Test]
        public void ThrowExceptionWhenAddExistingValue()
        {
            _sut.AddNew(1);
            _sut.AddNew(2);
            _sut.AddNew(3);
            Assert.AreEqual(3, _sut.Length);

            Assert.Throws<AddContainedValueException>(
                () =>
                {
                    _sut.AddNew(2);
                },
                "The value:2 is already in the list");
        }

        [Test]
        public void RemoveFromNotEmptyList()
        {
            _sut.AddNew(1);
            _sut.AddNew(2);
            _sut.AddNew(3);

            _sut.Remove(2);
            Assert.IsFalse(_sut.Contains(2));

            _sut.Remove(1);
            Assert.IsFalse(_sut.Contains(1));

            Assert.AreEqual(1, _sut.Length);
            Assert.AreEqual(3, _sut[0]);
        }

        [Test]
        public void ThrowExceptionWhenRemoveNotExistingValueTest()
        {
            _sut.AddNew(1);
            _sut.AddNew(2);
            _sut.AddNew(3);
            
            Assert.Throws<RemoveNotContainedValueException>(
                () =>
                {
                    _sut.Remove(4);
                },
                "The value:4 is not contained in the list!");
        }
    }
}
