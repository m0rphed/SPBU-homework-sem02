namespace Task_7._1
{
    using System;

    /// <summary>
    /// Interface for calculator
    /// </summary>
    public interface ICalculator
    {
        event Action<string> OnTextChange;

        void HandleDigit(int number);

        void HandleSpecialSymbol(SymbolType symbol);
    }
}
