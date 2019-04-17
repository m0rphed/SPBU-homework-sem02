namespace ProblemSet03.Task01
{
    /// <summary>
    /// Interface of the stack.
    /// </summary>
    /// <typeparam name="T">Data type of stack elements</typeparam>
    public interface IStack<T>
    {
        /// <summary>
        /// Returns count of elements of the stack
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Adds new element on top of the stack
        /// </summary>
        /// <param name="data">new value to push</param>
        void Push(T data);

        /// <summary>
        /// Removes element from top of the stack
        /// </summary>
        /// <returns>value that was removed from the stack</returns>
        /// <exception cref="System.Exception">Thrown when trying to pop from empty stack.</exception>
        T Pop();

        /// <summary>
        /// Returns element from top of the stack without removing it
        /// </summary>
        /// <returns>value of the top element</returns>
        T Peek();
    }
}
