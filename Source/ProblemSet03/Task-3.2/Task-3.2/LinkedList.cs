﻿namespace ProblemSet02.Task02
{
    using ProblemSet03.Task02;
    using System;

    /// <summary>
    /// Class implements linked list data structure
    /// </summary>
    public class LinkedList
    {
        /// <summary>
        /// Pointer to the first element
        /// </summary>
        private ListElement head;

        public int Head
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
        /// Adds new element on specified position
        /// Indexes starts from zero
        /// </summary>
        /// <param name="value">new value to add</param>
        /// <param name="position">index in the list</param>
        public void AddValueOnPosition(int value, int position)
        {
            if (position < 0 || position > Length)
            {
                throw new IndexOutOfRangeException($"Postition {position} is incorrect");
            }

            if (position == 0)
            {
                var newHeadElement = new ListElement(value, head);
                head = newHeadElement;
                ++Length;
                return;
            }

            var cursor = GetElementByPosition(position - 1);
            var newElement = new ListElement(value, cursor.Next);
            cursor.Next = newElement;
            ++Length;
        }

        /// <summary>
        /// Gets element by position
        /// </summary>
        /// <param name="position">index of element in the list</param>
        /// <returns>value of element on specified position</returns>
        public int GetValueByPosition(int position)
        {
            if (position < 0 || position >= Length)
            {
                throw new IndexOutOfRangeException($"Postition {position} is incorrect");
            }

            var cursor = GetElementByPosition(position);
            return cursor.Value;
        }

        ListElement GetElementByPosition(int position)
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
        public void ResetValueOnPosition(int value, int position)
        {
            if (position < 0 || position >= Length)
            {
                throw new IndexOutOfRangeException($"Postition {position} is incorrect");
            }

            var cursor = GetElementByPosition(position);

            cursor.Value = value;
        }

        /// <summary>
        /// Delete element on specified position
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
        /// Class implements element of linked list
        /// </summary>
        private class ListElement
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ListElement"/> class.
            /// Explicit constructor
            /// </summary>
            /// <param name="value">value of element</param>
            /// <param name="next">pointer to the next element</param>
            public ListElement(int value, ListElement next)
            {
                this.Value = value;
                this.Next = next;
            }

            /// <summary>
            /// Pointer to the next element
            /// </summary>
            public ListElement Next { get; set; }

            /// <summary>
            /// Value of element
            /// </summary>
            public int Value { get; set; }
        }
    }
}
