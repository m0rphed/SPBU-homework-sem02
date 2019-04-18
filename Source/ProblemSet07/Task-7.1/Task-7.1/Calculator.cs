using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_7._1
{
    public class Calculator : ICalculator
    {
        public event Action<string> OnTextChange;

        private string _currentText = string.Empty;

        private double _prevVal = double.NaN;

        private OperationType _currenOperation = OperationType.None;

        public void HandleDigit(int number)
        {
            _currentText += number.ToString();
            OnTextChange(_currentText);
        }

        private void PerformOperation(OperationType operation,
            double lastValue,
            double currentValue)
        {
            switch (operation)
            {
                case OperationType.Add:
                    {
                        var result = lastValue + currentValue;
                        _currentText = result.ToString();
                        OnTextChange(_currentText);
                    }
                    break;
            }
        }

        public void HandleOperation(OperationType opType)
        {
            switch(opType)
            {
                case OperationType.Equal:
                    {
                        if (Double.TryParse(_currentText, out double myVal))
                        {
                            if (_currenOperation != OperationType.None)
                            {
                                PerformOperation(_currenOperation,
                                    _prevVal, myVal);
                            }
                        }
                    }
                    break;
                case OperationType.Add:
                    {
                        if (Double.TryParse(_currentText, out double myVal))
                        {
                            if (double.IsNaN(_prevVal))
                            {
                                PerformOperation(_currenOperation, _prevVal, myVal);
                                _currenOperation = OperationType.Add;
                            }
                        }
                    }
                    break;
            }
        }

        private void ChangeTextOnScreen(string text)
        {
            _currentText = text;
            if (OnTextChange != null)
            {
                OnTextChange(_currentText);
            }
        }

        public void HandleUserTextChange(string newText)
        {
            void CutOperationFromText()
            {
                _currentText = newText.Substring(0, newText.Length - 1);
                OnTextChange(_currentText);
            }

            if (newText == _currentText)
            {
                return;
            }
            if (newText.Length > 0)
            {
                var possibleOp = newText.Substring(newText.Length - 1, 1);
                switch(possibleOp)
                {
                    case "+":
                        CutOperationFromText();
                        HandleOperation(OperationType.Add);
                        return;
                    case "-":
                        CutOperationFromText();
                        HandleOperation(OperationType.Subtract);
                        return;
                    case "*":
                        CutOperationFromText();
                        HandleOperation(OperationType.Multiply);
                        return;
                    case "/":
                        CutOperationFromText();
                        HandleOperation(OperationType.Divide);
                        return;
                    case "=":
                        CutOperationFromText();
                        HandleOperation(OperationType.Equal);
                        return;
                }
            }

            if (newText.Contains("x"))
            {
                ChangeTextOnScreen("????");
            }
            else
            {
                _currentText = newText;
            }

            /*
            var r = new Regex("/[0-9]/");
            if (!r.Match(newText).Success)
            {
                ChangeTextOnScreen("????");
            }
            else
            {
                // something else
            }
            */
        }
    }
}
