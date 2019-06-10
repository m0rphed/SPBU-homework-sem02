namespace Task_7._1
{
    using System;

    public class Calculator : ICalculator
    {
        private string statusLineText = string.Empty;

        private decimal prevVal = default;

        private bool lastActionIsOperation;

        private SymbolType currentSymbol = SymbolType.None;

        public event Action<string> OnTextChange;

        public void HandleDigit(int number)
        {
            var text = lastActionIsOperation ? number.ToString() : statusLineText + number.ToString();
            statusLineText = decimal.TryParse(text, out var val) ? val.ToString() : text;

            OnTextChange(statusLineText);
            lastActionIsOperation = false;
        }

        public void HandleSpecialSymbol(SymbolType symbol)
        {
            if (symbol == SymbolType.Dot)
            {
                statusLineText = lastActionIsOperation ? "0." : statusLineText + ".";
                OnTextChange(statusLineText);
                lastActionIsOperation = false;
                return;
            }

            lastActionIsOperation = true;

            if (symbol == SymbolType.Reset)
            {
                statusLineText = "0";
                prevVal = 0;
                currentSymbol = SymbolType.None;
                OnTextChange(statusLineText);
                return;
            }

            if (!decimal.TryParse(statusLineText, out decimal currentValue))
            {
                return;
            }

            switch (symbol)
            {
                case SymbolType.Negate:
                {
                    PerformInternalOperation(SymbolType.Negate, prevVal, currentValue);
                    currentSymbol = SymbolType.None;
                    break;
                }

                case SymbolType.Equal:
                    {
                        PerformInternalOperation(currentSymbol, prevVal, currentValue);
                        currentSymbol = SymbolType.None;
                        break;
                    }

                case SymbolType.Add:
                    {
                        PerformInternalOperation(currentSymbol, prevVal, currentValue);
                        currentSymbol = SymbolType.Add;
                        break;
                    }

                case SymbolType.Subtract:
                    {
                        PerformInternalOperation(currentSymbol, prevVal, currentValue);
                        currentSymbol = SymbolType.Subtract;
                        break;
                    }

                case SymbolType.Multiply:
                    {
                        PerformInternalOperation(currentSymbol, prevVal, currentValue);
                        currentSymbol = SymbolType.Multiply;
                        break;
                    }

                case SymbolType.Divide:
                    {
                        PerformInternalOperation(currentSymbol, prevVal, currentValue);
                        currentSymbol = SymbolType.Divide;
                        break;
                    }
            }
        }

        private void PerformInternalOperation(SymbolType currentSymbol, decimal prevVal, decimal myVal)
        {
            if (currentSymbol == SymbolType.None)
            {
                // stores previous value
                if (decimal.TryParse(statusLineText, out var val))
                {
                    this.prevVal = val;
                }

                return;
            }

            PerformArithmeticOperation(currentSymbol, prevVal, myVal);
        }

        // only supports arithmetic operations
        private void PerformArithmeticOperation(SymbolType symbol, decimal left, decimal right)
        {
            decimal result;

            void Success()
            {
                statusLineText = result.ToString();
                OnTextChange(statusLineText);
                prevVal = result;
            }

            void Failed(string message)
            {
                statusLineText = message;
                OnTextChange(statusLineText);
            }

            switch (symbol)
            {
                case SymbolType.Negate:
                    result = -right;
                    Success();
                    break;
                case SymbolType.Add:
                    result = left + right;
                    Success();
                    break;
                case SymbolType.Subtract:
                    result = left - right;
                    Success();
                    break;
                case SymbolType.Multiply:
                    result = left * right;
                    Success();
                    break;
                case SymbolType.Divide:
                    if (right == 0)
                    {
                        Failed("Cannot divide by zero");
                    }
                    else
                    {
                        result = left / right;
                        Success();
                    }

                    break;
                default:
                    return;
            }
        }
    }
}
