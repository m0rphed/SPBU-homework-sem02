namespace ProblemSet04.Task01
{
    /// <summary>
    /// Represent operator as node in the expression tree.
    /// </summary>
    public abstract class Operator : ITreeNode
    {
        private readonly string _symbol;

        protected Operator(ITreeNode left, ITreeNode right, string symbol)
        {
            _symbol = symbol;
            Left = left;
            Right = right;
        }

        public ITreeNode Left { get; }

        public ITreeNode Right { get; }

        /// <summary>
        /// Calculates operation.
        /// </summary>
        /// <returns>operand calculation result</returns>
        public abstract int Calculate();

        /// <summary>
        /// Prints string which represents operation expression.
        /// </summary>
        /// <returns>string which represents operator applied on its arguments</returns>
        public string Print() => $"( {Left.Print()} {_symbol} {Right.Print()} )";
    }
}
