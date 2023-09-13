namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);

                return items[Count - 1 - index];
            }
            set
            {
                ValidateIndex(index);

                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (items.Length == Count)
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
            for (int i = Count - 1; i >= 0; i--)
            {
                if (items[i].Equals(item))
                {
                    return Count - 1 - i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);

            if (Count == items.Length)
            {
                Grow();
            }

            var actualIndex = Count - index;

            for (int i = Count; i > actualIndex; i--)
            {
                items[i] = items[i - 1];
            }

            items[actualIndex] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            var actualIndex = Count - 1 - index;

            for (int i = actualIndex; i < Count; i++)
            {
                items[i] = items[i + 1];
            }

            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Grow()
        {
            var itemsCopy = new T[items.Length * 2];
            Array.Copy(items, itemsCopy, items.Length);
            items = itemsCopy;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }
    }
}