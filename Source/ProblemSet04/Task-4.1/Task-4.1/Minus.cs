namespace ProblemSet04.Task01
{
    public class Minus : Operator
    {
        public Minus(TreeNode left, TreeNode right)
            : base(left, right, "-")
        {
        }

        public override int Calculate() => Left.Calculate() - Right.Calculate();
    }
}
