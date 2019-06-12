namespace ProblemSet04.Task01
{
    /// <summary>
    /// Implements addition operation.
    /// </summary>
    public class Plus : Operator
    {
        public Plus(ITreeNode left, ITreeNode right)
            : base(left, right, "+")
        {
        }

        /// <inheritdoc/>
        public override int Calculate() => Left.Calculate() + Right.Calculate();
    }
}
