namespace ProblemSet04.Task02
{
    using System;

    /// <summary>
    /// Exception is thrown when trying to remove value which does not belong to the list
    /// </summary>
    [Serializable]
    public class RemoveNotContainedValueException : Exception
    {
        public RemoveNotContainedValueException() { }

        public RemoveNotContainedValueException(string message)
            : base(message) { }

        public RemoveNotContainedValueException(string message, Exception inner)
            : base(message, inner) { }

        protected RemoveNotContainedValueException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
