namespace ProblemSet04.Task01
{
    /// <summary>
    /// Implements multiplication operation.
    /// </summary>
    public class Multiply : Operator
    {
        public Multiply(ITreeNode left, ITreeNode right)
            : base(left, right, "*")
        {
        }

        /// <inheritdoc/>
        public override int Calculate() => Left.Calculate() * Right.Calculate();
    }
}
