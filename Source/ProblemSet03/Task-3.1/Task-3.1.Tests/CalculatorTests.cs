namespace ProblemSet03.Tests.Task01
{
    using System;
    using NUnit.Framework;
    using ProblemSet03.Task01;

    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void TestAddOperation()
        {
            var c = new Calculator(new StackFromArray<string>(100));
            var r = c.Evaluate("2 2 +");
            Assert.AreEqual(4.0, r);
        }

        [Test]
        public void TestAddNegativeValues()
        {
            var c = new Calculator(new StackFromArray<string>(100));
            var r = c.Evaluate("-2 2 +");
            Assert.AreEqual(0.0, r);
        }

        [Test]
        public void TestSubtructValues()
        {
            var c = new Calculator(new StackFromArray<string>(100));
            var r = c.Evaluate("3 4 -");
            Assert.AreEqual(-1.0, r);
        }

        [Test]
        public void TestDivideValues()
        {
            var c = new Calculator(new StackFromArray<string>(100));
            var r = c.Evaluate("12 4 /");
            Assert.AreEqual(3.0, r);
        }

        [Test]
        public void TestMultiplyValues()
        {
            var c = new Calculator(new StackFromArray<string>(100));
            var r = c.Evaluate("12 4 *");
            Assert.AreEqual(48.0, r);
        }

        [Test]
        public void TestComplexInputWithArray()
        {
            var c = new Calculator(new StackFromArray<string>(100));

            var r = c.Evaluate("-1 8 2 4 -1 / * + -");
            Assert.AreEqual(-1.0, r);
        }

        [Test]
        public void TestComplexInputWithList()
        {
            var c = new Calculator(new StackFromList<string>());

            var r = c.Evaluate("-1 8 2 4 -1 / * + -");
            Assert.AreEqual(-1.0, r);
        }

        [Test]
        public void ErrorOnOpButNoOperands()
        {
            Assert.Throws<Exception>(() =>
            {
                var c = new Calculator(new StackFromArray<string>(100));
                c.Evaluate("*");
            }, "Not enough operands!");
        }

        [Test]
        public void ErrorOnEmptyInput()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var c = new Calculator(new StackFromArray<string>(100));
                c.Evaluate("");
            }, "Input is Null or Empty");
        }

        [Test]
        public void ErrorOnNonDoubleFinalResult()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var c = new Calculator(new StackFromArray<string>(100));
                c.Evaluate("Not_A_Double 10 1 /");
            }, "Input is Null or Empty");
        }

        [Test]
        public void ErrorOnUnsupportedOperation()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var c = new Calculator(new StackFromArray<string>(100));
                c.Evaluate("10 1 Z");
            }, "Unsupported operation");
        }
    }
}
