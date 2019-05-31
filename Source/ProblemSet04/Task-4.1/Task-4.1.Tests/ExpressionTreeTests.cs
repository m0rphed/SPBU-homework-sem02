namespace ProblemSet04.Task01.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ExpressionTreeTests
    {
        [Test]
        public static void TestParseNumber()
        {
            var expression = "-2";
            var sut = new ExpressionTree(expression);
            Assert.AreEqual("-2", sut.Print());
        }

        [Test]
        public static void TestParseExpression()
        {
            var expression = "( + 2 2 )";
            var sut = new ExpressionTree(expression);
            Assert.AreEqual("( 2 + 2 )", sut.Print());
        }

        [Test]
        public static void TestParseExpressionWithSubExpession()
        {
            var expression = "( + 2 ( * 3 4 ) )";
            var sut = new ExpressionTree(expression);
            Assert.AreEqual("( 2 + ( 3 * 4 ) )", sut.Print());
        }

        [Test]
        public static void TestCalculateExpressionWithSubExpession()
        {
            var expression = "( + 2 ( * 3 4 ) )";
            var sut = new ExpressionTree(expression);
            Assert.AreEqual(14, sut.Calculate());
        }

        [Test]
        public static void TestExpressionWithZeros()
        {
            var expression = "( - 0 ( / 0 0 ) )";
            var sut = new ExpressionTree(expression);

            Assert.Throws<DivideByZeroException>(() =>
            {
                sut.Calculate();
            });

            Assert.AreEqual("( 0 - ( 0 / 0 ) )", sut.Print());
        }

        [Test]
        public static void TestExpressionWithQestionableDivision()
        {
            var expression = "( + 0 ( / 2 4 ) )";
            var sut = new ExpressionTree(expression);
            Assert.AreEqual(0, sut.Calculate());
        }
    }
}
