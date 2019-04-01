namespace ProblemSet01.Tests
{
    using NUnit.Framework;
    using ProblemSet01.Task_01;

    [TestFixture]
    public class FactorialTests
    {
        [Test]
        public void Test_PositiveInput()
        {
            var res = Factorial.CalculateFactorial(4);
            Assert.AreEqual(24, res);
        }

        [Test]
        public void Test_PositiveOne()
        {
            var res = Factorial.CalculateFactorial(1);
            Assert.AreEqual(1, res);
        }

        [Test]
        public void Test_PositiveLarge()
        {
            var res = Factorial.CalculateFactorial(10);
            Assert.AreEqual(3628800, res);
        }

        [Test]
        public void Test_EdgeCase_Zero()
        {
            var res = Factorial.CalculateFactorial(0);
            Assert.AreEqual(1, res);
        }
    }
}
