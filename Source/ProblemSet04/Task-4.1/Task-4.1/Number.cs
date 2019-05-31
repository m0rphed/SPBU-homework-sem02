namespace ProblemSet04.Task01
{
    /// <summary>
    /// Represent number as node in the expression tree.
    /// </summary>
    public class Number : ITreeNode
    {
        public Number(int value)
        {
            Value = value;
        }

        public int Value { get; }

        /// <summary>
        /// Returns numeric value.
        /// </summary>
        /// <returns>numeric value</returns>
        public int Calculate() => Value;

        /// <summary>
        /// Returns string which represents numeric value.
        /// </summary>
        /// <returns>string which represents numeric value</returns>
        public string Print() => Value.ToString();
    }
}
