﻿namespace ProblemSet02.Task02
{
    using System;

    /// <summary>
    /// Class implements hash table data structure
    /// using custom implementation of linked list
    /// </summary>
    /// <typeparam name="T">type of values in HashTable</typeparam>
    public class HashTableImplementation<T>
    {
        public const int TableSize = 128;

        /// <summary>
        /// Yet another amateur implementation of linked list
        /// </summary>
        private CustomLinkedList<T>[] _buckets;

        public HashTableImplementation(int newTableSize = TableSize)
        {
            _buckets = new CustomLinkedList<T>[newTableSize];
        }

        /// <summary>
        /// Number of values in hash table
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Adds new value to the hash table
        /// </summary>
        /// <param name="val">new value to add</param>
        public void Add(T val)
        {
            Add(val, true);
        }

        /// <summary>
        /// Removes value from the hash table
        /// </summary>
        /// <param name="val">value to remove from hash table</param>
        public void Remove(T val)
        {
            var index = GetBucketIndex(val);
            var list = _buckets[index];

            if (list != null && list.Contains(val))
            {
                list.RemoveElementByValue(val);
                --Count;
            }
        }

        /// <summary>
        /// Checks if value is in the hash table
        /// </summary>
        /// <param name="val">value for check</param>
        /// <returns>true if value is contained in the hash table</returns>
        public bool Contains(T val)
        {
            var index = GetBucketIndex(val);
            var list = _buckets[index];

            return list != null && list.Contains(val);
        }

        /// <summary>
        /// Changes size of hash table when necessary
        /// </summary>
        private void Resize()
        {

            var oldBuckets = _buckets;
            _buckets = new CustomLinkedList<T>[2 * _buckets.Length];
            Count = 0;

            foreach (var bucket in oldBuckets)
            {
                if (bucket != null)
                {
                    var current = bucket.Head;

                    while (current != null)
                    {
                        Add(current.Value, false);
                        current = current.Next;
                    }
                }
            }
        }

        private void Add(T val, bool checkResize)
        {
            if (checkResize && Count >= 2 * _buckets.Length)
            {
                Resize();
            }

            var index = GetBucketIndex(val);
            var list = _buckets[index];

            if (list == null)
            {
                list = new CustomLinkedList<T>();
                _buckets[index] = list;
            }

            if (list.Contains(val))
            {
                return;
            }

            list.AddValueOnPosition(val, 0);
            ++Count;
        }

        private int GetBucketIndex(T val) => Math.Abs(val.GetHashCode()) % _buckets.Length;
    }
}
