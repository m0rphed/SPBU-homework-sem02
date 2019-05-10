namespace ProblemSet04.Task01
{
    public class Number : TreeNode
    {
        public Number(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public override int Calculate() => Value;

        public override string Print() => Value.ToString();
    }
}
