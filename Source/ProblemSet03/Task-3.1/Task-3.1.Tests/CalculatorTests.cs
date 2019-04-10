namespace ProblemSet03.Tests.Task01
{
    using System;
    using NUnit.Framework;
    using ProblemSet03.Task01;

    /// <summary>
    /// Provides two different implementations of <see cref="IStack{T}"/>.
    /// </summary>
    public class MyFixtureData
    {
        public static Func<IStack<string>> buildFromArray = () => new StackFromArray<string>(100);
        public static Func<IStack<string>> buildFromList = () => new StackFromList<string>();

        public static object[] FixtureParms
        {
            get
            {
                return new object[]
                {
                    new object[] { buildFromArray, "From array" },
                    new object[] { buildFromList, "From list" }
                };
            }
        }
    }

    [TestFixtureSource(typeof(MyFixtureData), "FixtureParms")]
    public class CalculatorTests
    {
        private Func<IStack<string>> _createStack;

        public CalculatorTests(Func<IStack<string>> stack, string testName)
        {
            _createStack = stack;
        }

        public Calculator CreateCalculator()
        {
            return new Calculator(_createStack());
        }

        [Test]
        public void TestAddOperation()
        {
            var result = CreateCalculator().Evaluate("2 2 +");
            Assert.AreEqual(4.0, result);
        }

        [Test]
        public void TestAddNegativeValues()
        {
            var result = CreateCalculator().Evaluate("-2 2 +");
            Assert.AreEqual(0.0, result, 1.0e-10);
        }

        [Test]
        public void TestSubtructValues()
        {
            var result = CreateCalculator().Evaluate("3 4 -");
            Assert.AreEqual(-1.0, result, 1.0e-10);
        }

        [Test]
        public void TestDivideValues()
        {
            var result = CreateCalculator().Evaluate("12 4 /");
            Assert.AreEqual(3.0, result, 1.0e-10);
        }

        [Test]
        public void TestMultiplyValues()
        {
            var result = CreateCalculator().Evaluate("12 4 *");
            Assert.AreEqual(48.0, result, 1.0e-10);
        }

        [Test]
        public void TestComplexInputWithArray()
        {
            var result = CreateCalculator().Evaluate("-1 8 2 4 -1 / * + -");
            Assert.AreEqual(-1.0, result, 1.0e-10);
        }

        [Test]
        public void TestComplexInputWithList()
        {
            var result = CreateCalculator().Evaluate("-1 8 2 4 -1 / * + -");
            Assert.AreEqual(-1.0, result, 1.0e-10);
        }

        [Test]
        public void ErrorOnOpButNoOperands()
        {
            Assert.Throws<Exception>(() =>
            {
                CreateCalculator().Evaluate("*");
            }, "Not enough operands!");
        }

        [Test]
        public void ErrorOnEmptyInput()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                CreateCalculator().Evaluate("");
            }, "Input is Null or Empty");
        }

        [Test]
        public void ErrorOnNonDoubleFinalResult()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                CreateCalculator().Evaluate("Not_A_Double 10 1 /");
            }, "Input is Null or Empty");
        }

        [Test]
        public void ErrorOnUnsupportedOperation()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                CreateCalculator().Evaluate("10 1 Z");
            }, "Unsupported operation");
        }
    }
}
