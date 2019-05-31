namespace ProblemSet04.Task02
{
    using System;

    /// <summary>
    /// Represents a strongly typed list of objects that can be accessed by index.
    /// Provides methods to manipulate lists.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list</typeparam>
    public class CustomList<T>
    {
        /// <summary>
        /// Gets number of elements of the list
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the IList is read-only
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets pointer to the first element
        /// </summary>
        private CustomListElement<T> Head { get; set; }

        public T this[int index] => GetValueByPosition(index);

        /// <summary>
        /// Adds new element on specified position.
        /// Indexes starts from zero
        /// </summary>
        /// <param name="value">new value to add</param>
        /// <param name="position">index in the list</param>
        public virtual void AddValueOnPosition(T value, int position)
        {
            if (position < 0 || position > Length)
            {
                throw new IndexOutOfRangeException($"Position {position} is incorrect");
            }

            if (position == 0)
            {
                var newHeadElement = new CustomListElement<T>(value, Head);
                Head = newHeadElement;
                ++Length;
                return;
            }

            var cursor = GetElementByPosition(position - 1);
            var newElement = new CustomListElement<T>(value, cursor.Next);
            cursor.Next = newElement;
            ++Length;
        }

        /// <summary>
        /// Gets value by position
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
        /// Removes the first occurrence of a specific object from the list.
        /// </summary>
        /// <param name="value">value to remove</param>
        /// <returns>true if item is successfully removed; otherwise, false</returns>
        public virtual bool Remove(T value)
        {
            if (Length == 0)
            {
                throw new EmptyListException("Could not delete from empty list");
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

        /// <summary>
        /// Checks if list is empty
        /// </summary>
        /// <returns>true if list is empty, otherwise false</returns>
        public bool IsEmpty() => Length == 0;

        /// <summary>
        /// Adds new specific value to the list
        /// </summary>
        /// <param name="value">value to add</param>
        public virtual void AddNew(T value)
        {
            AddValueOnPosition(value, Length);
        }

        /// <summary>
        /// Removes all elements from the list
        /// </summary>
        public void Clear()
        {
            Head = null;
            Length = 0;
        }

        /// <summary>
        /// Copies the entire list to a compatible one-dimensional array,
        /// starting at the specified index of the target array
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from list</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - arrayIndex < Length)
            {
                throw new ArgumentException();
            }

            var counter = 0;
            for (var current = Head; current != null; current = current.Next)
            {
                array[arrayIndex + counter] = current.Value;
                counter++;
            }
        }

        /// <summary>
        /// Determines whether an element is in the list
        /// </summary>
        /// <param name="value">The object to locate in the list</param>
        /// <returns>true if item is found in the list; otherwise, false</returns>
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
        /// Gets element by position
        /// </summary>
        /// <param name="position">position of the element</param>
        /// <returns>element on specified position</returns>
        private CustomListElement<T> GetElementByPosition(int position)
        {
            var cursor = Head;
            for (var i = 0; i < position; ++i)
            {
                cursor = cursor.Next;
            }

            return cursor;
        }

        /// <summary>
        /// Class implements element of linked list
        /// </summary>
        /// <typeparam name="T">type of value</typeparam>
        private class CustomListElement<T>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CustomListElement{T}"/> class.
            /// Explicit constructor.
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

        private static bool ElementEquals(T left, T right) => object.Equals(left, right);
    }
}
