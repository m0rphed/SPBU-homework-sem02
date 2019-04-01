namespace ProblemSet01.Task_02
{
    /// <summary>
    /// Class provides method for calculation Fibonacci number
    /// </summary>
    public class Fibonacci
    {
        /// <summary>
        /// Calculating the n-th member of Fibonacci sequence
        /// </summary>
        /// <returns>Fibonacci number</returns>
        /// <param name="n">Unsigned int number</param>
        public static ulong CalculateFibonacci(uint n)
            => CalculateFibonacci(0, 1, n);

        private static ulong CalculateFibonacci(ulong last, ulong current, uint n)
            => (n < 1) ? last : (n == 1) ? current : CalculateFibonacci(current, last + current, n - 1);
    }
}
