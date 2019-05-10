namespace ProblemSet04.Task01
{
    public class Divide : Operator
    {
        public Divide(TreeNode left, TreeNode right)
            : base(left, right, "/")
        {
        }

        public override int Calculate() => Left.Calculate() / Right.Calculate();
    }
}
