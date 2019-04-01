namespace ProblemSet01.Tests
{
    using NUnit.Framework;
    using ProblemSet01.Task_02;

    [TestFixture]
    public class FibonacciTests
    {
        [Test]
        public void Fibonacci_PositiveInput()
        {
            var res = Fibonacci.CalculateFibonacci(4);
            Assert.AreEqual(3, res);
        }

        [Test]
        public void Fibonacci_PositiveOne()
        {
            var res = Fibonacci.CalculateFibonacci(1);
            Assert.AreEqual(1, res);
        }

        [Test]
        public void Fibonacci_PositiveLarge()
        {
            var res = Fibonacci.CalculateFibonacci(10);
            Assert.AreEqual(55, res);
        }

        [Test]
        public void Fibonacci_EdgeCase_Zero()
        {
            var res = Fibonacci.CalculateFibonacci(0);
            Assert.AreEqual(0, res);
        }
    }
}
