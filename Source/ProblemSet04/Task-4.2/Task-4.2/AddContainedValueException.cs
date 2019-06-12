namespace ProblemSet04.Task02
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// Exception is thrown when trying to add value which already belongs to the list
    /// </summary>
    [Serializable]
    public class AddContainedValueException : Exception
    {
        public AddContainedValueException() { }

        public AddContainedValueException(string message)
            : base(message) { }

        public AddContainedValueException(string message, Exception inner)
            : base(message, inner) { }

        protected AddContainedValueException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
