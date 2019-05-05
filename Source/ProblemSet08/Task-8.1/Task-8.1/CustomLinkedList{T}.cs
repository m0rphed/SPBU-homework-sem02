namespace ProblemSet08.Task01
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Class implements linked list data structure
    /// </summary>
    public class CustomLinkedList<T> : IList<T>
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

        public int Count => Length;

        /// <summary>
        /// Gets a value indicating whether the IList is read-only
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Returns an enumerator that iterates through the list
        /// </summary>
        /// <returns>IEnumerator of specified type</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Checks if list is empty
        /// </summary>
        /// <returns>true if list is empty, otherwise false</returns>
        public bool IsEmpty() => Length == 0;

        public void Add(T item)
        {
            AddValueOnPosition(item, Length);
        }

        /// <summary>
        /// Removes all elements from the CustomLinkedList.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Length = 0;
        }

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
        /// Removes the first occurrence of a specific object from the CustomLinkedList
        /// </summary>
        /// <param name="item">item to remove</param>
        /// <returns>true if item is successfully removed; otherwise, false.</returns>
        public bool Remove(T item) => RemoveElementByValue(item);

        public int IndexOf(T item)
        {
            var index = 0;
            for (var current = Head; current != null; current = current.Next)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, item))
                {
                    return index;
                }

                index++;
            }

            // Index not found
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index >= Length)
            {
                throw new ArgumentOutOfRangeException("Index must be within the bounds of the List");
            }

            var current = Head;
            var previous = Head;

            for (var i = 0; i < index; ++i)
            {
                previous = current;
                current = current.Next;
            }

            previous.Next = new CustomLinkedListElement<T>(item, current);
        }

        public void RemoveAt(int index)
        {
            RemoveElementByPosition(index);
        }

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

        public T this[int index]
        {
            get => GetValueByPosition(index);
            set => ResetValueOnPosition(value, index);
        }
    }
}
