using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7._1
{
    public enum OperationType
    {
        Add,
        Divide,
        Percent,
        Equal,
        Reset // clear or AC
    }

    public enum OperationSymbol
    {
        Dot,
        SignPlus,
        SignMinus
    }

    public interface ICalculator
    {
        event Action<string> OnTextChange;
        void HandleDigit(int number);
        void HandleSymbol(OperationSymbol opSymbol);
        void HandleOperation(OperationType opType);
    }
}
