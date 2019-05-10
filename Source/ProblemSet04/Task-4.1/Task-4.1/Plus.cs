namespace ProblemSet04.Task01
{
    public class Plus : Operator
    {
        public Plus(TreeNode left, TreeNode right)
            : base(left, right, "+")
        {
        }

        public override int Calculate() => Left.Calculate() + Right.Calculate();
    }
}
