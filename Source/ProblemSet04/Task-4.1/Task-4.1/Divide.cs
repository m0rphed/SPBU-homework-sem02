namespace ProblemSet04.Task01
{
    /// <summary>
    /// Implements division operation.
    /// </summary>
    public class Divide : Operator
    {
        public Divide(ITreeNode left, ITreeNode right)
            : base(left, right, "/")
        {
        }

        /// <inheritdoc/>
        public override int Calculate() => Left.Calculate() / Right.Calculate();
    }
}
