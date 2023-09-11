namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }

                return items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }

                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (Count == items.Length)
            {
                Grow();
            }

            items[Count] = item;
            Count++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            var copyArray = new T[Count + 1];

            Array.Copy(items, copyArray, index);

            copyArray[index] = item;

            Array.Copy(items, index, copyArray, index + 1, Count - index);

            items = copyArray;
            Count++;
        }

        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }

            var copyArray = new T[Count - 1];

            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    Array.Copy(items, copyArray, i);
                    Array.Copy(items, i + 1, copyArray, i, Count - 1 - i);
                    items = copyArray;
                    Count--;
                    break;
                }
            }
            return true;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            var copyArray = new T[Count - 1];

            Array.Copy(items, copyArray, index);
            Array.Copy(items, index + 1, copyArray, index, Count - 1 - index);
            items = copyArray;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void Grow()
        {
            var itemsCopy = new T[Count * 2];

            for (int i = 0; i < Count; i++)
            {
                itemsCopy[i] = items[i];
            }

            items = itemsCopy;
        }
    }
}