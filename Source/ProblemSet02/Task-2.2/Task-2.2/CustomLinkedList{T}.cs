namespace ProblemSet02.Task02
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
        private ListElement<T> head;

        public T Head
        {
            get
            {
                if (head == null)
                {
                    throw new EmptyListException();
                }

                return head.Value;
            }

            set
            {
                if (head == null)
                {
                    throw new EmptyListException();
                }

                head.Value = value;
            }
        }

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
        /// Checks if value is alredy in the list
        /// </summary>
        /// <param name="value">value to check</param>
        /// <returns>true, if value is in the list, otherwise false</returns>
        public bool Contains(T value)
        {
            var current = head;

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
                throw new IndexOutOfRangeException($"Postition {position} is incorrect");
            }

            if (position == 0)
            {
                var newHeadElement = new ListElement<T>(value, head);
                head = newHeadElement;
                ++Length;
                return;
            }

            var cursor = GetElementByPosition(position - 1);
            var newElement = new ListElement<T>(value, cursor.Next);
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
                throw new IndexOutOfRangeException($"Postition {position} is incorrect");
            }

            var cursor = GetElementByPosition(position);
            return cursor.Value;
        }

        ListElement<T> GetElementByPosition(int position)
        {
            var cursor = head;
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
                throw new IndexOutOfRangeException($"Postition {position} is incorrect");
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
                throw new IndexOutOfRangeException($"Postition {position} is incorrect");
            }

            if (position == 0)
            {
                head = head.Next;
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

            if (ElementEquals(head.Value, value))
            {
                head = head.Next;
                --Length;
                return true;
            }

            var current = head;
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

        private bool ElementEquals(T left, T right) => object.Equals(left, right);

        /// <summary>
        /// Class implements element of linked list
        /// </summary>
        private class ListElement<T>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ListElement"/> class.
            /// Explicit constructor
            /// </summary>
            /// <param name="value">value of element</param>
            /// <param name="next">pointer to the next element</param>
            public ListElement(T value, ListElement<T> next)
            {
                this.Value = value;
                this.Next = next;
            }

            /// <summary>
            /// Pointer to the next element
            /// </summary>
            public ListElement<T> Next { get; set; }

            /// <summary>
            /// Value of element
            /// </summary>
            public T Value { get; set; }
        }
    }
}
