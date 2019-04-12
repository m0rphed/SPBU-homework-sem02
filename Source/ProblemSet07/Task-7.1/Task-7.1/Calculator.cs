using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7._1
{
    public class Calculator : ICalculator
    {
        public event Action<string> OnTextChange;

        private string _itext = string.Empty;

        public void HandleDigit(int number)
        {
            _itext += number.ToString();
            OnTextChange(_itext);
        }

        public void HandleOperation(OperationType opType)
        {
            switch(opType)
            {
                case OperationType.Add:
                    // todo
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public void HandleSymbol(OperationSymbol symbol)
        {
        }
    }
}
