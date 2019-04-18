using System;
using System.Diagnostics.Contracts;

namespace Task_7._1
{
    public class Calculator : ICalculator
    {
        public event Action<string> OnTextChange;

        private string _statusLineText = string.Empty;

        private decimal _prevVal = default(decimal);

        private bool _lastActionIsOperation;

        private SymbolType _currentSymbol = SymbolType.None;

        public void HandleDigit(int number)
        {
            var text = _lastActionIsOperation ? number.ToString() : _statusLineText + number.ToString();
            _statusLineText = decimal.TryParse(text, out var val) ? val.ToString() : text;

            OnTextChange(_statusLineText);
            _lastActionIsOperation = false;
        }

        public void HandleSpecialSymbol(SymbolType symbol)
        {
            if (symbol == SymbolType.Dot)
            {
                _statusLineText = _lastActionIsOperation ? "0." : _statusLineText + ".";
                OnTextChange(_statusLineText);
                _lastActionIsOperation = false;
                return;
            }

            _lastActionIsOperation = true;

            if (symbol == SymbolType.Reset)
            {
                _statusLineText = "0";
                _prevVal = 0;
                _currentSymbol = SymbolType.None;
                OnTextChange(_statusLineText);
                return;
            }

            if (!decimal.TryParse(_statusLineText, out decimal currentValue))
            {
                return;
            }

            switch (symbol)
            {
                case SymbolType.Negate:
                {
                    PerformInternalOperation(SymbolType.Negate, _prevVal, currentValue);
                    _currentSymbol = SymbolType.None;
                    break;
                }

                case SymbolType.Equal:
                    {
                        PerformInternalOperation(_currentSymbol, _prevVal, currentValue);
                        _currentSymbol = SymbolType.None;
                        break;
                    }

                case SymbolType.Add:
                    {
                        PerformInternalOperation(_currentSymbol, _prevVal, currentValue);
                        _currentSymbol = SymbolType.Add;
                        break;
                    }

                case SymbolType.Subtract:
                    {
                        PerformInternalOperation(_currentSymbol, _prevVal, currentValue);
                        _currentSymbol = SymbolType.Subtract;
                        break;
                    }

                case SymbolType.Multiply:
                    {
                        PerformInternalOperation(_currentSymbol, _prevVal, currentValue);
                        _currentSymbol = SymbolType.Multiply;
                        break;
                    }

                case SymbolType.Divide:
                    {
                        PerformInternalOperation(_currentSymbol, _prevVal, currentValue);
                        _currentSymbol = SymbolType.Divide;
                        break;
                    }
            }
        }

        private void PerformInternalOperation(SymbolType currentSymbol, decimal prevVal, decimal myVal)
        {
            if (currentSymbol == SymbolType.None)
            {
                // stores previous value
                if (decimal.TryParse(_statusLineText, out var val))
                {
                    _prevVal = val;
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
                _statusLineText = result.ToString();
                OnTextChange(_statusLineText);
                _prevVal = result;
            }

            void Failed(string message)
            {
                _statusLineText = message;
                OnTextChange(_statusLineText);
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
