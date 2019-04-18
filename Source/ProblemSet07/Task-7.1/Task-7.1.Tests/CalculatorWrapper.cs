namespace Task_7._1.Tests
{
    public class CalculatorWrapper
    {
        public CalculatorWrapper()
        {
            Calculator = new Calculator();
            Calculator.OnTextChange += Calculator_OnTextChange;
        }

        public ICalculator Calculator { get; private set; }

        public string StatusLine { get; private set; }

        private void Calculator_OnTextChange(string text)
        {
            StatusLine = text;
        }
    }
}
