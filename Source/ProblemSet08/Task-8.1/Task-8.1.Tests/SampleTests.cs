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
    public class SampleTests
    {
        private readonly Func<IList<string>> _createList;

        public SampleTests(Func<IList<string>> list, string testName)
        {
            _createList = list;
        }

        [Test]
        public void TestsIterator()
        {
            var sut = _createList();
            sut.Add("X1");
            var res = sut.Select(a => a).ToList();
            Assert.AreEqual(sut[0], res[0]);
        }

        [Test]
        public void InsertTest()
        {
            var sut = _createList();
            sut.Add("first");
            sut.Add("second");
            sut.Add("third");
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.Insert(sut.Count + 1, "One more element"));
            Assert.True(ex.Message.Contains("Index must be within the bounds of the List"));
        }
    }

    // public IEnumerator<T> GetEnumerator()
    // IEnumerator IEnumerable.GetEnumerator()
    // public int IndexOf(T item)
    // public void Insert(int index, T item)
    // public void RemoveAt(int index)
    // T this[int index]

}