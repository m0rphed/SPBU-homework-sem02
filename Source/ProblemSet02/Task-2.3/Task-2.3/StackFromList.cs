namespace ProblemSet02.Task03
{
    using System;

    /// <summary>
    /// Represents implementation of a stack using lists.
    /// </summary>
    /// <typeparam name="ElementType">represents data type of a stack element</typeparam>
    public class StackFromList<ElementType> : IStack<ElementType>
    {
        private StackFromListItem<ElementType> _topItem;

        public int Count { get; private set; }

        public ElementType Peek() => _topItem.Data;

        public ElementType Pop()
        {
            if (Count == 0)
            {
                throw new Exception("Could not pop from empty stack");
            }

            Count--;
            var storedValue = _topItem.Data;
            _topItem = _topItem.NextDown;
            return storedValue;
        }

        public void Push(ElementType data)
        {
            Count++;
            var lastTop = _topItem;
            _topItem = new StackFromListItem<ElementType>(data, lastTop);
        }

        private class StackFromListItem<T>
        {
            internal readonly T Data;
            internal readonly StackFromListItem<T> NextDown;

            /// <summary>
            /// Initializes a new instance of the <see cref="StackFromListItem{T}"/> class.
            /// Explicit comstructor of stack element.
            /// </summary>
            /// <param name="data">Element data</param>
            /// <param name="nextDown">Pointer to next (down) element in the stack</param>
            internal StackFromListItem(T data, StackFromListItem<T> nextDown)
            {
                Data = data;
                NextDown = nextDown;
            }
        }
    }
}
