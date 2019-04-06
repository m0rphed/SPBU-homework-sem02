namespace ProblemSet02.Task01
{
    using System;

    /// <summary>
    /// Exception is thrown when the operation cannot be performed
    /// on empty linked list
    /// </summary>
    [Serializable]
    public class EmptyListException : ApplicationException
    {
        public EmptyListException()
        {
        }

        // Throws with custom message (could be specified)
        public EmptyListException(string message)
            : base(message)
        {
        }

        public EmptyListException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected EmptyListException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
