namespace ProblemSet03.Task01
{
    using System;

    /// <summary>
    /// Represents implementation of a stack using arrays.
    /// </summary>
    /// <typeparam name="ElementType">represents data type of a stack element</typeparam>
    public class StackFromArray<ElementType> : IStack<ElementType>
    {
        private ElementType[] _array;

        public StackFromArray(int size)
        {
            _array = new ElementType[size];
            Count = 0;
        }

        public int Count { get; private set; }

        public ElementType Peek()
        {
            return _array[Count - 1];
        }

        public ElementType Pop()
        {
            if (Count == 0)
            {
                throw new Exception("Stack is empty");
            }

            Count--;
            return _array[Count];
        }

        public void Push(ElementType data)
        {
            if (Count >= _array.Length)
            {
                var expandedArray = new ElementType[_array.Length * 2];

                for (int i = 0; i < _array.Length; ++i)
                {
                    expandedArray[i] = _array[i];
                }

                _array = expandedArray;
            }

            _array[Count] = data;
            Count++;
        }
    }
}
