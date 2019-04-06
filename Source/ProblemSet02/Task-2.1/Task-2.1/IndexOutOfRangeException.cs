namespace ProblemSet02.Task01
{
    using System;

    /// <summary>
    /// Exception is thrown when given element position (index in the list) is incorrect
    /// </summary>
    [Serializable]
    public class IndexOutOfRangeException : ApplicationException
    {
        public IndexOutOfRangeException()
        {
        }

        // Throws with custom message (could be specified)
        public IndexOutOfRangeException(string message)
            : base(message)
        {
        }

        public IndexOutOfRangeException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected IndexOutOfRangeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
