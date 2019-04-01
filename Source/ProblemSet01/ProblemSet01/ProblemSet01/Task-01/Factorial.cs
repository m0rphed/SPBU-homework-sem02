namespace ProblemSet01.Task_01
{
    /// <summary>
    /// Class provides method for calculation factorial of a number
    /// </summary>
    public class Factorial
    {
        /// <summary>
        /// Calculating the factorial of given argument
        /// </summary>
        /// <returns>The factorial of a number</returns>
        /// <param name="number">Any uint value</param>
        public static uint CalculateFactorial(uint number)
            => number <= 1 ? 1 : number * CalculateFactorial(number - 1);
    }
}
