namespace ProblemSet04.Task01
{
    public class Minus : Operator
    {
        public Minus(ITreeNode left, ITreeNode right)
            : base(left, right, "-")
        {
        }

        /// <inheritdoc/>
        public override int Calculate() => Left.Calculate() - Right.Calculate();
    }
}
