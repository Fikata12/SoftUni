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

            if (Count == items.Length)
            {
                Grow();
            }

            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;

            Count++;
        }

        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }

            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    for (int j = i; j < Count; j++)
                    {
                        items[j] = items[j + 1];
                    }

                    items[Count] = default;

                    Count--;

                    if (Count < items.Length / 2)
                    {
                        Shrink();
                    }

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

            Array.Clear(items, 0, Count);
            Array.Copy(copyArray, items, copyArray.Length);

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
            var itemsCopy = new T[items.Length * 2];

            Array.Copy(items, itemsCopy, items.Length);

            items = itemsCopy;
        }

        void Shrink()
        {
            var itemsCopy = new T[items.Length / 2];

            Array.Copy(items, itemsCopy, Count);

            items = itemsCopy;
        }
    }
}