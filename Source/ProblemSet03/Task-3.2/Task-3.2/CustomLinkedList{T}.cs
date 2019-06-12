namespace ProblemSet03.Task02
{
    using System;

    /// <summary>
    /// Class implements linked list data structure
    /// </summary>
    public class CustomLinkedList<T>
    {
        /// <summary>
        /// Pointer to the first element
        /// </summary>
        public CustomLinkedListElement<T> Head { get; private set; }

        /// <summary>
        /// Number of elements of the list
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Checks if list is empty
        /// </summary>
        /// <returns>true if list is empty, otherwise false</returns>
        public bool IsEmpty() => Length == 0;

        /// <summary>
        /// Checks if value is already in the list
        /// </summary>
        /// <param name="value">value to check</param>
        /// <returns>true, if value is in the list, otherwise false</returns>
        public bool Contains(T value)
        {
            var current = Head;

            for (var i = 0; i < Length; ++i)
            {
                if (ElementEquals(current.Value, value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Adds new element on specified position
        /// Indexes starts from zero
        /// </summary>
        /// <param name="value">new value to add</param>
        /// <param name="position">index in the list</param>
        public void AddValueOnPosition(T value, int position)
        {
            if (position < 0 || position > Length)
            {
                throw new IndexOutOfRangeException($"Position {position} is incorrect");
            }

            if (position == 0)
            {
                var newHeadElement = new CustomLinkedListElement<T>(value, Head);
                Head = newHeadElement;
                ++Length;
                return;
            }

            var cursor = GetElementByPosition(position - 1);
            var newElement = new CustomLinkedListElement<T>(value, cursor.Next);
            cursor.Next = newElement;
            ++Length;
        }

        /// <summary>
        /// Gets element by position
        /// </summary>
        /// <param name="position">index of element in the list</param>
        /// <returns>value of element on specified position</returns>
        public T GetValueByPosition(int position)
        {
            if (position < 0 || position >= Length)
            {
                throw new IndexOutOfRangeException($"Position {position} is incorrect");
            }

            var cursor = GetElementByPosition(position);
            return cursor.Value;
        }

        public CustomLinkedListElement<T> GetElementByPosition(int position)
        {
            var cursor = Head;
            for (var i = 0; i < position; ++i)
            {
                cursor = cursor.Next;
            }

            return cursor;
        }

        /// <summary>
        /// Changes value of list element on specified position
        /// </summary>
        /// <param name="value">new value for the element on specified position</param>
        /// <param name="position">index of element to change</param>
        public void ResetValueOnPosition(T value, int position)
        {
            if (position < 0 || position >= Length)
            {
                throw new IndexOutOfRangeException($"Position {position} is incorrect");
            }

            var cursor = GetElementByPosition(position);

            cursor.Value = value;
        }

        /// <summary>
        /// Deletes element on specified position
        /// </summary>
        /// <param name="position">index of element to delete</param>
        public void RemoveElementByPosition(int position)
        {
            if (Length == 0)
            {
                throw new EmptyListException("Could not delete from empty list");
            }

            if (position < 0 || position >= Length)
            {
                throw new IndexOutOfRangeException($"Position {position} is incorrect");
            }

            if (position == 0)
            {
                Head = Head.Next;
                --Length;
                return;
            }

            var cursor = GetElementByPosition(position - 1);
            cursor.Next = cursor.Next.Next;
            --Length;
        }

        /// <summary>
        /// Deletes first found element with specified value
        /// </summary>
        /// <param name="value">value to delete</param>
        /// <returns>true if element was successfully removed, otherwise false</returns>
        public bool RemoveElementByValue(T value)
        {
            if (Length == 0)
            {
                throw new EmptyListException("Could not delete from empty list");
            }

            if (!Contains(value))
            {
                throw new Exception($"Value: {value} is not contained in the list");
            }

            if (ElementEquals(Head.Value, value))
            {
                Head = Head.Next;
                --Length;
                return true;
            }

            var current = Head;
            for (var i = 0; i < Length - 1; ++i)
            {
                if (ElementEquals(current.Next.Value, value))
                {
                    current.Next = current.Next.Next;
                    --Length;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        private static bool ElementEquals(T left, T right) => object.Equals(left, right);
    }
}
