namespace ProblemSet04.Task01
{
    public abstract class Operator : TreeNode
    {
        private readonly string _symbol;

        protected Operator(TreeNode left, TreeNode right, string symbol)
        {
            _symbol = symbol;
            Left = left;
            Right = right;
        }

        public TreeNode Left { get; }

        public TreeNode Right { get; }

        public override string Print() => $"( {Left.Print()} {_symbol} {Right.Print()} )";
    }
}
