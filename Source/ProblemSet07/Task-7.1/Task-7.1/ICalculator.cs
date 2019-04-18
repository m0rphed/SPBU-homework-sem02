using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7._1
{
    public interface ICalculator
    {
        event Action<string> OnTextChange;

        void HandleDigit(int number);

        void HandleOperation(OperationType opType);

        void HandleUserTextChange(string newText);
    }
}
