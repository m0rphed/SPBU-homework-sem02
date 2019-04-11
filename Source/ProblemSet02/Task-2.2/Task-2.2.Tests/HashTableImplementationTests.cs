namespace ProblemSet02.Task02
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class HashTableImplementationTests
    {
        [Test]
        public void RemoveIfContainedInTable()
        {
            var sut = new HashTableImplementation<string>();
            sut.Add("собачка");
            Assert.IsTrue(sut.Contains("собачка"));
            Assert.IsFalse(sut.Contains("кошечка"));
        }

        [Test]
        public void RemoveValuesFromTable()
        {
            var sut = new HashTableImplementation<string>();

            sut.Add("собачка");
            Assert.IsTrue(sut.Contains("собачка"));
            sut.Add("кошечка");
            Assert.IsTrue(sut.Contains("кошечка"));

            sut.Remove("собачка");
            Assert.IsFalse(sut.Contains("собачка"));

            sut.Remove("кошечка");
            Assert.IsFalse(sut.Contains("кошечка"));
        }

        [Test]
        public void AddManyThenRemoveMany()
        {
            var sut = new HashTableImplementation<string>();

            sut.Add("Овечка Долли");
            sut.Add("Овечка Долли");
            sut.Add("Овечка Долли");
            Assert.AreEqual(3, sut.Count);

            sut.Remove("Овечка Долли");
            sut.Remove("Овечка Долли");
            Assert.IsTrue(sut.Contains("Овечка Долли"));
            Assert.AreEqual(1, sut.Count);

            sut.Remove("Овечка Долли");
            Assert.IsFalse(sut.Contains("Овечка Долли"));
            Assert.AreEqual(0, sut.Count);
        }
    }
}
