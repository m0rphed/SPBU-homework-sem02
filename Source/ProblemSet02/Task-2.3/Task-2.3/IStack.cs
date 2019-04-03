namespace ProblemSet02.Task03
{
    /// <summary>
    /// Interface of the stack.
    /// </summary>
    /// <typeparam name="T">Data type of stack elements</typeparam>
    public interface IStack<T>
    {
        int Count { get; }

        void Push(T data);

        T Pop();

        T Peek();
    }
}
