namespace ProblemSet04.Task02
{
    /// <inheritdoc />
    /// <summary>
    /// Class implements linked list where every value is unique.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list</typeparam>
    public class UniqueList<T> : CustomList<T>
    {
        /// <summary>
        /// Adds new specific unique value to the list
        /// </summary>
        /// <param name="value">unique value to add</param>
        public override void AddNew(T value)
        {
            if (Contains(value))
            {
                throw new AddContainedValueException($"The value:{value} is already in the list");
            }

            base.AddNew(value);
        }

        /// <summary>
        /// Removes occurrence of a specific unique value from the list.
        /// </summary>
        /// <param name="value">value to remove</param>
        /// <returns>true if item is successfully removed; otherwise, false</returns>
        public override bool Remove(T value)
        {
            if (!Contains(value))
            {
                throw new RemoveNotContainedValueException($"The value:{value} is not contained in the list");
            }

            return base.Remove(value);
        }
    }
}
