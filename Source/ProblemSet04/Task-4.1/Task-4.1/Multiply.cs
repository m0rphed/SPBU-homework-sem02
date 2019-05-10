namespace ProblemSet04.Task01
{
    public class Multiply : Operator
    {
        public Multiply(TreeNode left, TreeNode right)
            : base(left, right, "*")
        {
        }

        public override int Calculate() => Left.Calculate() * Right.Calculate();
    }
}
