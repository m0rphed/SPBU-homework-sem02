namespace ProblemSet04.Task02
{
    /// <summary>
    /// Class implements element of linked list
    /// </summary>
    /// <typeparam name="T">type of value</typeparam>
    public class CustomListElement<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomListElement{T}"/> class
        /// Explicit constructor
        /// </summary>
        /// <param name="value">value of element</param>
        /// <param name="next">pointer to the next element</param>
        public CustomListElement(T value, CustomListElement<T> next)
        {
            this.Value = value;
            this.Next = next;
        }

        /// <summary>
        /// Gets or sets pointer to the next element
        /// </summary>
        public CustomListElement<T> Next { get; set; }

        /// <summary>
        /// Gets or sets value of element
        /// </summary>
        public T Value { get; set; }
    }
}
