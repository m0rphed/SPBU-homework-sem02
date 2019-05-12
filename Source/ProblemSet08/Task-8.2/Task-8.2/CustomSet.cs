namespace ProblemSet08.Task02
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <inheritdoc/>
    public partial class CustomSet<T> : ISet<T>
    {
        private Node<T> _top;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public class Node<T>
        {
            public Node(T value)
            {
                Value = value;
            }

            public Node<T> Left { get; set; }

            public Node<T> Right { get; set; }

            public T Value { get; set; }
        }

        private static readonly Comparer<T> _comparer = Comparer<T>.Default;

        /// <inheritdoc/>
        void ICollection<T>.Add(T item)
        {
            InternalAdd(item);
        }

        /// <inheritdoc/>
        bool ISet<T>.Add(T item)
        {
            return InternalAdd(item);
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            var values = new List<T>();
            if (_top != null)
            {
                TraverseBuildList(_top, values);
            }

            foreach (var item in values)
            {
                yield return item;
            }
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc/>
        public void Clear()
        {
            _top = null;
            Count = 0;
        }

        /// <inheritdoc/>
        public bool Contains(T item)
        {
            var values = new List<T>();
            if (_top != null)
            {
                TraverseBuildList(_top, values);
            }

            return values.Contains(item);
        }

        /// <inheritdoc/>
        public void CopyTo(T[] array, int arrayIndex)
        {
            var values = new List<T>();
            if (_top != null)
            {
                TraverseBuildList(_top, values);
            }

            for (var i = 0; i < values.Count; i++)
            {
                array[i + arrayIndex] = values[i];
            }
        }

        /// <inheritdoc/>
        public void UnionWith(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                InternalAdd(item);
            }
        }

        /// <inheritdoc/>
        public void IntersectWith(IEnumerable<T> other)
        {
            var otherSet = new HashSet<T>(other);
            var valuesToRemove = new List<T>();

            foreach (var existingValue in this)
            {
                if (!otherSet.Contains(existingValue))
                {
                    valuesToRemove.Add(existingValue);
                }
            }

            foreach (var deletable in valuesToRemove)
            {
                this.Remove(deletable);
            }
        }

        /// <inheritdoc/>
        public void ExceptWith(IEnumerable<T> other)
        {
            var otherSet = new HashSet<T>(other);

            foreach (var valueToRemove in otherSet)
            {
                this.Remove(valueToRemove);
            }
        }

        /// <inheritdoc/>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            var otherSet = new HashSet<T>(other);
            var valuesToRemove = new List<T>();
            var valuesToAdd = new List<T>();

            foreach (var existingValue in this)
            {
                if (otherSet.Contains(existingValue))
                {
                    valuesToRemove.Add(existingValue);
                }
            }

            foreach (var anotherValue in otherSet)
            {
                if (!this.Contains(anotherValue))
                {
                    valuesToAdd.Add(anotherValue);
                }
            }

            foreach (var deletable in valuesToRemove)
            {
                this.Remove(deletable);
            }

            foreach (var addable in valuesToAdd)
            {
                this.InternalAdd(addable);
            }
        }

        /// <inheritdoc/>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            var otherSet = new HashSet<T>(other);

            foreach (var existingValue in this)
            {
                if (!otherSet.Contains(existingValue))
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc/>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            var otherSet = new HashSet<T>(other);

            foreach (var anotherValue in otherSet)
            {
                if (!Contains(anotherValue))
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc/>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            var otherSet = new HashSet<T>(other);

            foreach (var anotherValue in otherSet)
            {
                if (!Contains(anotherValue))
                {
                    return false;
                }
            }

            return Count != otherSet.Count;
        }

        /// <inheritdoc/>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            var otherSet = new HashSet<T>(other);

            foreach (var existingValue in this)
            {
                if (!otherSet.Contains(existingValue))
                {
                    return false;
                }
            }

            return Count != otherSet.Count;
        }

        /// <inheritdoc/>
        public bool Overlaps(IEnumerable<T> other)
        {
            var otherSet = new HashSet<T>(other);

            foreach (var existingValue in this)
            {
                if (otherSet.Contains(existingValue))
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        public bool SetEquals(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var otherSet = new HashSet<T>(other);

            if (this.Count != otherSet.Count)
            {
                return false;
            }

            foreach (var existingValue in this)
            {
                if (!otherSet.Contains(existingValue))
                {
                    return false;
                }
            }

            foreach (var anotherValue in otherSet)
            {
                if (!this.Contains(anotherValue))
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc/>
        public bool Remove(T oldItem)
        {
            return _top != null && TraverseRemove(null, _top, oldItem);
        }

        private bool InternalAdd(T item)
        {
            if (_top == null)
            {
                _top = new Node<T>(item);
                Count++;
                return true;
            }

            return TraverseAdd(_top, item);
        }

        private bool TraverseRemove(Node<T> parent, Node<T> current, T oldItem)
        {
            // precondition - current node is not null
            switch (_comparer.Compare(oldItem, current.Value))
            {
                case 0:
                    Count--;

                    if (current.Left == null && current.Right == null)
                    {
                        if (parent != null)
                        {
                            if (parent.Left == current)
                            {
                                parent.Left = null;
                                return true;
                            }

                            // second choice - if (parent.Right == current)
                            parent.Right = null;
                            return true;
                        }

                        _top = null;
                        return true;
                    }

                    if (current.Left == null)
                    {
                        if (parent != null)
                        {
                            if (parent.Left == current)
                            {
                                parent.Left = current.Right;
                                return true;
                            }

                            // second choice - if (parent.Right == current)
                            parent.Right = current.Right;
                            return true;
                        }

                        _top = current.Right;
                        return true;
                    }

                    if (current.Right != null)
                    {
                        return true;
                    }

                    if (parent != null)
                    {
                        if (parent.Left == current)
                        {
                            parent.Left = current.Left;
                            return true;
                        }

                        // second choice - if (parent.Right == current)
                        parent.Right = current.Left;
                        return true;
                    }

                    _top = current.Left;
                    return true;

                case 1:
                    if (current.Left != null)
                    {
                        return TraverseRemove(current, current.Left, oldItem);
                    }

                    return false;

                case -1:
                    if (current.Right != null)
                    {
                        return TraverseRemove(current, current.Right, oldItem);
                    }

                    return false;

                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private bool TraverseAdd(Node<T> current, T newItem)
        {
            // precondition - current node is not null
            switch (_comparer.Compare(newItem, current.Value))
            {
                case 0:
                    return false; // already added
                case 1:
                    if (current.Left == null)
                    {
                        Count++;
                        current.Left = new Node<T>(newItem);
                        return true;
                    }
                    else
                    {
                        return TraverseAdd(current.Left, newItem);
                    }

                case -1:
                    if (current.Right == null)
                    {
                        Count++;
                        current.Right = new Node<T>(newItem);
                        return true;
                    }
                    else
                    {
                        return TraverseAdd(current.Right, newItem);
                    }

                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private void TraverseBuildList(Node<T> current, List<T> values)
        {
            if (current.Left != null)
            {
                TraverseBuildList(current.Left, values);
            }

            values.Add(current.Value);

            if (current.Right != null)
            {
                TraverseBuildList(current.Right, values);
            }
        }
    }
}
