namespace ProblemSet03.Task02.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class HashFunctionsTests
    {
        private HashFromStringFunction _stringHash;
        private HashFromGenericFunction<string> _genericHashForString;
        private HashFromGenericFunction<int> _genericHashForInt;
        private HashFromIntFunction _intHash;

        [SetUp]
        public void Initialize()
        {
            _stringHash = new HashFromStringFunction();
            _genericHashForString = new HashFromGenericFunction<string>();
            _genericHashForInt = new HashFromGenericFunction<int>();
            _intHash = new HashFromIntFunction();
        }

        private static void AddRemoveOneItem<T>(IHashFunction<T> func, T[] elements)
        {
            var sut = new HashTableImplementation<T>(128, func);
            sut.Add(elements[0]);
            Assert.AreEqual(1, sut.Count);
            sut.Remove(elements[0]);
            Assert.AreEqual(0, sut.Count);
        }

        [Test]
        public void AddAndRemoveItemUsingCustomStringHash() =>
            AddRemoveOneItem<string>(_stringHash, new[] { "TestItem" });

        [Test]
        public void AddAndRemoveItemUsingCustomGenericStringHash() =>
            AddRemoveOneItem<string>(_genericHashForString, new[] { "TestItem" });

        [Test]
        public void AddAndRemoveItemUsingCustomIntHash() =>
            AddRemoveOneItem<int>(_intHash, new[] { 11 });

        [Test]
        public void AddAndRemoveItemUsingCustomGenericIntHash() =>
            AddRemoveOneItem<int>(_genericHashForInt, new[] { 11 });

        private static void AddRemoveThreeElements<T>(IHashFunction<T> func, T[] e)
        {
            var sut = new HashTableImplementation<T>(128, func);

            sut.Add(e[0]);
            sut.Add(e[1]);
            sut.Add(e[2]);

            sut.Remove(e[0]);
            sut.Remove(e[0]);
            sut.Remove(e[2]);

            Assert.IsFalse(sut.Contains(e[0]));
            Assert.IsFalse(sut.Contains(e[2]));
            Assert.IsTrue(sut.Contains(e[1]));
        }

        [Test]
        public void AddRemoveThreeElementsUsingCustomStringHash() =>
            AddRemoveThreeElements<string>(_stringHash, new[] { "Alpha", "Beta", "Gamma" });

        [Test]
        public void AddRemoveThreeElementsUsingCustomGenericStringHash() =>
            AddRemoveThreeElements<string>(_genericHashForString, new[] { "Alpha", "Beta", "Gamma" });

        [Test]
        public void AddRemoveThreeElementsUsingCustomIntHash() =>
            AddRemoveThreeElements<int>(_intHash, new[] { 3, 5, 7 });

        [Test]
        public void AddRemoveThreeElementsUsingCustomGenericIntHash() =>
            AddRemoveThreeElements<int>(_genericHashForInt, new[] { 3, 5, 7 });
    }
}
