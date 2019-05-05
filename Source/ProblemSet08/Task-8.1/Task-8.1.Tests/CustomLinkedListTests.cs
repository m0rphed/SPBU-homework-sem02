namespace ProblemSet08.Task01.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    /// <summary>
    /// Provides two different implementations of <see cref="IList{T}"/>.
    /// </summary>
    public static class MyFixtureData
    {
        private static readonly Func<IList<string>> customList = () => new CustomLinkedList<string>();
        private static readonly Func<IList<string>> standardList = () => new List<string>();

        public static object[] FixtureParams => new object[]
        {
            new object[] { standardList, $"{nameof(List<string>)}" },
            new object[] { customList, $"{nameof(CustomLinkedList<string>)}" }
        };
    }

    [TestFixtureSource(typeof(MyFixtureData), "FixtureParams")]
    [TestFixture]
    public class CustomLinkedListTests
    {
        private readonly Func<IList<string>> _createList;

        public CustomLinkedListTests(Func<IList<string>> list, string testName)
        {
            _createList = list;
        }

        [Test]
        public void AddMethodTest()
        {
            var sut = _createList();
            sut.Add("1");
            sut.Add("2");
            sut.Add("3");
            Assert.AreEqual(3, sut.Count);
            Assert.AreEqual("2", sut[1]);
        }

        [Test]
        public void IteratorTest()
        {
            var sut = _createList();
            sut.Add("X1");
            sut.Add("X2");
            sut.Add("X3");
            var res = sut.Select(a => a).ToList();
            Assert.AreEqual("X1", res[0]);
            Assert.AreEqual("X2", res[1]);
            Assert.AreEqual("X3", res[2]);
        }

        [Test]
        public void InsertMethodTest()
        {
            var sut = _createList();
            sut.Add("first");
            sut.Add("second");
            sut.Add("third");
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.Insert(sut.Count + 1, "One more element"));
            Assert.True(ex.Message.Contains("Index must be within the bounds of the List"));
        }

        [Test]
        public void IndexerMethodTest()
        {
            var sut = _createList();

            sut.Add("something");
            sut.Add("another thing");
            sut.Add("Garfield");

            Assert.AreEqual("something", sut[0]);
            Assert.AreEqual("another thing", sut[1]);
            Assert.AreEqual("Garfield", sut[2]);

            Assert.AreEqual(sut.Count, 3);
            sut[0] = "Woody";
            sut[2] = "Woody";
            Assert.AreEqual("Woody", sut[0]);
            Assert.AreEqual("Woody", sut[2]);
        }

        [Test]
        public void ClearMethodTest()
        {
            var sut = _createList();
            sut.Add("something");
            sut.Clear();
            Assert.AreEqual(0, sut.Count);

            // Checks enumeration for empty list
            var res = sut.Select(a => a).ToList();
            Assert.AreEqual(0, res.Count);
        }

        [Test]
        public void CopyToMethodTest()
        {
            var sut = _createList();
            var res = new string[]
            {
                "0", "1", "2", "3", "4",
                "5", "6", "7", "8", "9",
                "10", "11", "12", "13", "14"
            };

            foreach (var item in new[] {"W0", "W1", "W2", "W3", "W4"})
            {
                sut.Add(item);
            }

            sut.CopyTo(res, 5);
            Assert.AreEqual(new []
            {
                "0", "1", "2", "3", "4",
                "W0", "W1", "W2", "W3", "W4",
                "10","11", "12", "13", "14"
            }, res);
        }

        [Test]
        public void SimpleRemoveMethodTest()
        {
            var sut = _createList();
            sut.Add("Poison");
            sut.Add("Mushroom");
            sut.Add("Magic wand");

            Assert.True(sut.Remove("Mushroom"));

            Assert.AreEqual(2, sut.Count);
            Assert.AreEqual("Magic wand", sut[1]);
            Assert.AreEqual("Poison", sut[0]);

            Assert.False(sut.Remove("Mushroom"));
            Assert.False(sut.Remove("Magic stones?"));
        }

        [Test]
        public void IndexOfMethodTest()
        {
            var sut = _createList();
            sut.Add("Something");
            sut.Add("the Fish");
            sut.Add("the Mouse");
            sut.Add("the Fish");

            Assert.AreEqual(4, sut.Count);
            Assert.AreEqual(1, sut.IndexOf("the Fish"));
            Assert.AreEqual(2, sut.IndexOf("the Mouse"));
        }

        [Test]
        public void RemoveAtMethodTest()
        {
            var sut = _createList();
            sut.Add("something");
            Assert.AreEqual("something", sut[0]);
        }

        [Test]
        public void ContainsMethodTest()
        {
            var sut = _createList();
            sut.Add("something");
            Assert.AreEqual("something", sut[0]);
        }
    }

    // public IEnumerator<T> GetEnumerator()
    // IEnumerator IEnumerable.GetEnumerator()
    // public int IndexOf(T item)
    // public void Insert(int index, T item)
    // public void RemoveAt(int index)
    // T this[int index]

}