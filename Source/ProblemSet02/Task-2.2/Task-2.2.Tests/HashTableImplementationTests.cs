namespace ProblemSet02.Task02
{
    using System;
    using System.Collections.Generic;
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

        [Test]
        public void HeavyUsage()
        {
            var vals = new List<string>();
            var r = new Random(1);
            var sut = new HashTableImplementation<string>();

            for (int i = 0; i < 100000; i++)
            {
                var val = r.NextDouble().ToString();
                sut.Add(val);
                vals.Add(val);
            }

            var count = 0;

            foreach(var item in vals)
            {
                if (item == "0.534899531647051")
                {
                    count++;
                }
            }

            Assert.AreEqual(1, count);

            while (vals.Count > 0)
            {
                var index = r.Next(0, vals.Count - 1);
                var val = vals[index];
                vals.RemoveAt(index);
                sut.Remove(val);
            }

            Assert.AreEqual(0, sut.Count);
        }

        [Test]
        public void TwoSameValues()
        {
            var sut = new HashTableImplementation<string>();

            sut.Add("a bird");
            sut.Add("a bird");
            Assert.AreEqual(2, sut.Count);
            Assert.IsTrue(sut.Contains("a bird"));

            sut.Remove("a bird");
            Assert.IsTrue(sut.Contains("a bird"));
            sut.Remove("a bird");
            Assert.IsFalse(sut.Contains("a bird"));
            Assert.AreEqual(0, sut.Count);
        }
    }
}
