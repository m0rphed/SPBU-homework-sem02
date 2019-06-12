namespace ProblemSet04.Task01
{
    /// <summary>
    /// Implements an arithmetic expression parse tree node.
    /// </summary>
    public interface ITreeNode
    {
        /// <summary>
        /// Calculate an expression by its value.
        /// </summary>
        /// <returns>Expression result.</returns>
        int Calculate();

        /// <summary>
        /// Returns string representation of the node and any sub-nodes.
        /// </summary>
        /// <returns>string representation of the node.</returns>
        string Print();
    }
}
