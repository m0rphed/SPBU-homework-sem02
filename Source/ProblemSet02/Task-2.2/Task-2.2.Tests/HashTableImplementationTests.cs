namespace ProblemSet02.Task02.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class HashTableImplementationTests
    {
        [Test]
        public void FindSingleInsertedItem()
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
        public void TestMultipleResize()
        {
            const int maxElementsToUse = 100000;
            var sut = new HashTableImplementation<string>(128);

            // creates pseudo-random unique values
            var testValues = new HashSet<string>();
            var r = new Random(1);
            for (var i = 0; i < maxElementsToUse; ++i)
            {
                var val = r.NextDouble().ToString(CultureInfo.InvariantCulture);
                testValues.Add(val);
            }

            var testValuesList = testValues.ToList();

            // populates hash table
            foreach (var item in testValuesList)
            {
                sut.Add(item);
            }

            // all values should be inserted
            Assert.AreEqual(testValuesList.Count, sut.Count);

            // pseudo-randomly removes values
            while (testValuesList.Count > 0)
            {
                var index = r.Next(0, testValuesList.Count - 1);
                var val = testValuesList[index];
                testValuesList.RemoveAt(index);
                sut.Remove(val);
            }

            // all values should be removed
            Assert.AreEqual(0, sut.Count);
        }

        [Test]
        public void TwoSameValues()
        {
            var sut = new HashTableImplementation<string>();

            sut.Add("a bird");
            sut.Add("a bird");
            Assert.AreEqual(1, sut.Count);
            Assert.IsTrue(sut.Contains("a bird"));

            sut.Remove("a bird");
            Assert.IsFalse(sut.Contains("a bird"));

            Assert.AreEqual(0, sut.Count);
        }
    }
}
