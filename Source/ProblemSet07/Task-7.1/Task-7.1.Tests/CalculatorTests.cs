namespace Task_3._2.Tests
{
    using NUnit.Framework;
    using Task_7._1;
    using Task_7._1.Tests;

    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void DivideByZeroMustShowMessage()
        {
            var c = new CalculatorWrapper();

            // Reset "0" 1 "1" / "1" 0 "0" = "Cannot divide by zero"
            c.Calculator.HandleSpecialSymbol(SymbolType.Reset);
            Assert.AreEqual("0", c.StatusLine);

            c.Calculator.HandleDigit(1);
            Assert.AreEqual("1", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Divide);
            Assert.AreEqual("1", c.StatusLine);

            c.Calculator.HandleDigit(0);
            Assert.AreEqual("0", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Equal);
            Assert.AreEqual("Cannot divide by zero", c.StatusLine);
        }

        [Test]
        public void AddTwoValues()
        {
            var c = new CalculatorWrapper();

            // Case: 3 + 5 =
            // Reset "0" 3 "3" + "3" 5 "5" = "8"
            c.Calculator.HandleSpecialSymbol(SymbolType.Reset);
            Assert.AreEqual("0", c.StatusLine);

            c.Calculator.HandleDigit(3);
            Assert.AreEqual("3", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Add);
            Assert.AreEqual("3", c.StatusLine);

            c.Calculator.HandleDigit(5);
            Assert.AreEqual("5", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Equal);
            Assert.AreEqual("8", c.StatusLine);
        }

        [Test]
        public void AddThreeValues()
        {
            var c = new CalculatorWrapper();

            // Case2: 1 + 2 + 3 =
            //    Reset "0" 1 "1" + "1" 2 "2" + "3" 3 "3" = "6"
            c.Calculator.HandleSpecialSymbol(SymbolType.Reset);
            Assert.AreEqual("0", c.StatusLine);

            c.Calculator.HandleDigit(1);
            Assert.AreEqual("1", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Add);
            Assert.AreEqual("1", c.StatusLine);

            c.Calculator.HandleDigit(2);
            Assert.AreEqual("2", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Add);
            Assert.AreEqual("3", c.StatusLine);

            c.Calculator.HandleDigit(3);
            Assert.AreEqual("3", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Equal);
            Assert.AreEqual("6", c.StatusLine);
        }

        [Test]
        public void CalcMixedStatement()
        {
            var c = new CalculatorWrapper();

            // Case3: 3 * 4 + 5 * 6 =
            // Reset "0" 3 "3" * "3" 4 "4" + "12" 5 "5" * "17" 6 "6" = "102"
            c.Calculator.HandleSpecialSymbol(SymbolType.Reset);
            Assert.AreEqual("0", c.StatusLine);

            c.Calculator.HandleDigit(3);
            Assert.AreEqual("3", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Multiply);
            Assert.AreEqual("3", c.StatusLine);

            c.Calculator.HandleDigit(4);
            Assert.AreEqual("4", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Add);
            Assert.AreEqual("12", c.StatusLine);

            c.Calculator.HandleDigit(5);
            Assert.AreEqual("5", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Multiply);
            Assert.AreEqual("17", c.StatusLine);

            c.Calculator.HandleDigit(6);
            Assert.AreEqual("6", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Equal);
            Assert.AreEqual("102", c.StatusLine);
        }

        [Test]
        public void AddTwoValuesThenEnterFraction()
        {
            var c = new CalculatorWrapper();

            // Case: 3 + 5 = .1 + 2 = 2.1
            // Verifies that we can enter fraction that clears previous value
            // Reset "0" 3 "3" + "3" 5 "5" = "8" . "0." 1 "0.1" + "0.1" 2 "2" = "2.1"
            // i.e instead of "8.0" we have "0." i.e. we reset value
            c.Calculator.HandleSpecialSymbol(SymbolType.Reset);
            Assert.AreEqual("0", c.StatusLine);

            c.Calculator.HandleDigit(3);
            Assert.AreEqual("3", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Add);
            Assert.AreEqual("3", c.StatusLine);

            c.Calculator.HandleDigit(5);
            Assert.AreEqual("5", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Equal);
            Assert.AreEqual("8", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Dot);
            Assert.AreEqual("0.", c.StatusLine);

            c.Calculator.HandleDigit(1);
            Assert.AreEqual("0.1", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Add);
            Assert.AreEqual("0.1", c.StatusLine);

            c.Calculator.HandleDigit(2);
            Assert.AreEqual("2", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Equal);
            Assert.AreEqual("2.1", c.StatusLine);
        }

        [Test]
        public void AddTwoValuesWhenSecondWithFraction()
        {
            var c = new CalculatorWrapper();

            // Case: 3 + 5.1 =
            // Reset "0" 3 "3" + "3" 5 "5" . "5." 7 "5.7" = "8.7"
            c.Calculator.HandleSpecialSymbol(SymbolType.Reset);
            Assert.AreEqual("0", c.StatusLine);

            c.Calculator.HandleDigit(3);
            Assert.AreEqual("3", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Add);
            Assert.AreEqual("3", c.StatusLine);

            c.Calculator.HandleDigit(5);
            Assert.AreEqual("5", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Dot);
            Assert.AreEqual("5.", c.StatusLine);

            c.Calculator.HandleDigit(7);
            Assert.AreEqual("5.7", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Equal);
            Assert.AreEqual("8.7", c.StatusLine);
        }

        [Test]
        public void NegateInputValue()
        {
            var c = new CalculatorWrapper();

            // 1 -/+ 
            // Reset "0" 1 "1" -/+ "-1"
            c.Calculator.HandleSpecialSymbol(SymbolType.Reset);
            Assert.AreEqual("0", c.StatusLine);

            c.Calculator.HandleDigit(1);
            Assert.AreEqual("1", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Negate);
            Assert.AreEqual("-1", c.StatusLine);

        }


        [Test]
        public void AddTwoValuesNegateResult()
        {
            var c = new CalculatorWrapper();

            // Case: 3 + 5 = +/-
            // Reset "0" 3 "3" + "3" 5 "5" = "8" +/- "-8"
            c.Calculator.HandleSpecialSymbol(SymbolType.Reset);
            Assert.AreEqual("0", c.StatusLine);

            c.Calculator.HandleDigit(3);
            Assert.AreEqual("3", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Add);
            Assert.AreEqual("3", c.StatusLine);

            c.Calculator.HandleDigit(5);
            Assert.AreEqual("5", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Equal);
            Assert.AreEqual("8", c.StatusLine);

            c.Calculator.HandleSpecialSymbol(SymbolType.Negate);
            Assert.AreEqual("-8", c.StatusLine);
        }


    }
}