namespace ProblemSet02.Task02
{
    /// <summary>
    /// Class implements element of linked list
    /// </summary>
    /// <typeparam name="T">type of value</typeparam>
    public class CustomLinkedListElement<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomLinkedListElement{T}"/> class.
        /// Explicit constructor
        /// </summary>
        /// <param name="value">value of element</param>
        /// <param name="next">pointer to the next element</param>
        public CustomLinkedListElement(T value, CustomLinkedListElement<T> next)
        {
            this.Value = value;
            this.Next = next;
        }

        /// <summary>
        /// Pointer to the next element
        /// </summary>
        public CustomLinkedListElement<T> Next { get; set; }

        /// <summary>
        /// Value of element
        /// </summary>
        public T Value { get; set; }
    }
}
