namespace ProblemSet02.Task02
{
    using System;

    public class HashTableImplementation<T>
    {
        public const int TableSize = 128;

        private CustomLinkedList<T>[] buckets;

        public HashTableImplementation(int newTableSize = TableSize)
        {
            buckets = new CustomLinkedList<T>[newTableSize];
        }

        public int Count { get; private set; }

        public void Add(T val)
        {
            var index = GetBucketIndex(val);
            var list = buckets[index];

            if (list == null)
            {
                list = new CustomLinkedList<T>();
                buckets[index] = list;
            }

            list.AddValueOnPosition(val, 0);
            ++Count;
        }

        public void Remove(T val)
        {
            var index = GetBucketIndex(val);
            var list = buckets[index];

            if (list != null)
            {
                if (list.RemoveElementByValue(val))
                {
                    --Count;
                }
            }
        }

        public bool Contains(T val)
        {
            var index = GetBucketIndex(val);
            var list = buckets[index];

            return list == null ? false : list.Contains(val);
        }

        private void Resize()
        {
            throw new NotImplementedException();
        }

        private int GetBucketIndex(T val) => Math.Abs(val.GetHashCode()) % buckets.Length;
    }
}
