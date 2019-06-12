namespace ProblemSet08.Task02.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixtureSource(typeof(CustomSetTestData), "FixtureParams")]
    [TestFixture]
    public class CustomSetTests
    {
        private readonly Func<ISet<string>> _createSet;

        public CustomSetTests(Func<ISet<string>> set, string testName)
        {
            _createSet = set;
        }

        [Test]
        public void AddUniqueElements()
        {
            var sut = _createSet();
            sut.Add("Key1");
            sut.Add("Key2");
            sut.Add("Key3");
            Assert.AreEqual(3, sut.Count);
            Assert.True(sut.Contains("Key1"));
            Assert.True(sut.Contains("Key2"));
            Assert.True(sut.Contains("Key3"));
        }

        [Test]
        public void RemoveUniqueElement()
        {
            var sut = _createSet();
            sut.Add("Key1");
            sut.Add("Key2");
            sut.Add("Key3");
            sut.Remove("Key2");
            Assert.AreEqual(2, sut.Count);
            Assert.True(sut.Contains("Key1"));
            Assert.False(sut.Contains("Key2"));
            Assert.True(sut.Contains("Key3"));
        }

        [Test]
        public void ClearElements()
        {
            var sut = _createSet();
            sut.Add("Key1");
            sut.Add("Key2");
            sut.Add("Key3");
            Assert.AreEqual(3, sut.Count);
            Assert.AreEqual(3, sut.AsEnumerable().ToList().Count);
            sut.Clear();
            Assert.AreEqual(0, sut.Count);
            Assert.AreEqual(0, sut.AsEnumerable().ToList().Count);
        }

        [Test]
        public void TestUnionWith()
        {
            var sut = _createSet();
            sut.Add("cat");
            sut.Add("dog");
            sut.Add("chicken");
            sut.UnionWith(new[] { "cat", "duck", "goose" });
            Assert.IsTrue(sut.Contains("cat"));
            Assert.IsTrue(sut.Contains("dog"));
            Assert.IsTrue(sut.Contains("chicken"));
            Assert.IsTrue(sut.Contains("duck"));
            Assert.IsTrue(sut.Contains("goose"));
            Assert.AreEqual(5, sut.AsEnumerable().ToList().Count);
        }

        [Test]
        public void TestIntersectWith()
        {
            var sut = _createSet();
            sut.Add("cat");
            sut.Add("dog");
            sut.Add("chicken");
            sut.IntersectWith(new[] { "cat", "duck", "goose", "dog" });
            Assert.IsTrue(sut.Contains("cat"));
            Assert.IsTrue(sut.Contains("dog"));
            Assert.AreEqual(2, sut.AsEnumerable().ToList().Count);
        }

        [Test]
        public void ExceptWith()
        {
            var sut = _createSet();
            sut.Add("cat");
            sut.Add("dog");
            sut.Add("chicken");
            sut.ExceptWith(new[] { "cat", "duck", "goose", "dog" });
            Assert.IsTrue(sut.Contains("chicken"));
            Assert.AreEqual(1, sut.AsEnumerable().ToList().Count);
        }

        [Test]
        public void TestSymmetricExceptWith()
        {
            var sut = _createSet();
            sut.Add("cat");
            sut.Add("dog");
            sut.Add("chicken");
            sut.SymmetricExceptWith(new[] { "cat", "duck", "goose", "dog" });
            Assert.IsTrue(sut.Contains("chicken"));
            Assert.IsTrue(sut.Contains("duck"));
            Assert.IsTrue(sut.Contains("goose"));
            Assert.AreEqual(3, sut.AsEnumerable().ToList().Count);
        }

        [Test]
        public void TestIsSubsetOf()
        {
            var sut = _createSet();
            sut.Add("cat");
            sut.Add("dog");
            sut.Add("chicken");
            Assert.IsTrue(sut.IsSubsetOf(new[] { "cat", "duck", "goose", "dog", "chicken" }));
            Assert.IsTrue(sut.IsSubsetOf(new[] { "cat", "dog", "chicken" }));
            Assert.IsFalse(sut.IsSubsetOf(new[] { "cat", "chicken" }));
        }

        [Test]
        public void TestIsSupersetOf()
        {
            var sut = _createSet();
            sut.Add("cat");
            sut.Add("dog");
            sut.Add("chicken");
            sut.Add("mouse");
            Assert.IsTrue(sut.IsSupersetOf(new[] { "cat", "chicken" }));
            Assert.IsFalse(sut.IsSupersetOf(new[] { "cat", "goose", "chicken" }));
            Assert.IsTrue(sut.IsSupersetOf(new string[] { }));
            Assert.IsTrue(sut.IsSupersetOf(new[] { "cat", "dog", "mouse", "chicken" }));
        }

        [Test]
        public void TestIsProperSupersetOf()
        {
            var sut = _createSet();
            sut.Add("1");
            sut.Add("3");
            sut.Add("5");
            Assert.IsFalse(sut.IsProperSupersetOf(new[] { "1", "3", "5" }));
            Assert.IsTrue(sut.IsProperSupersetOf(new[] { "1", "5" }));
        }

        [Test]
        public void TestIsProperSubsetOf()
        {
            var sut = _createSet();
            sut.Add("1");
            sut.Add("5");
            Assert.IsFalse(sut.IsProperSubsetOf(new[] { "1", "5" }));
            Assert.IsTrue(sut.IsProperSubsetOf(new[] { "1", "3", "5" }));
        }

        [Test]
        public void TestOverlaps()
        {
            var sut = _createSet();
            sut.Add("1");
            sut.Add("2");
            sut.Add("3");
            sut.Add("4");
            sut.Add("5");
            Assert.IsTrue(sut.Overlaps(new[] { "1" }));
            Assert.IsFalse(sut.Overlaps(new string[] { }));
            Assert.IsTrue(sut.Overlaps(new[] { "1", "2", "3", "4", "5" }));
            Assert.IsFalse(sut.Overlaps(new[] { "6", "7", "8", "9", "10" }));
        }

        [Test]
        public void TestSetEquals()
        {
            var sut = _createSet();
            sut.Add("1");
            sut.Add("2");
            sut.Add("3");
            sut.Add("4");
            sut.Add("5");
            Assert.IsTrue(sut.SetEquals(new[] { "1", "2", "3", "4", "5" }));
            Assert.IsFalse(sut.SetEquals(new[] { "1", "2", "3", "4", "6" }));
        }
    }
}
