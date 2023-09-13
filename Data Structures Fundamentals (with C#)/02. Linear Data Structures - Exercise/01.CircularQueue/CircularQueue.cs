namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] elements;

        private int startIndex;

        private int endIndex;

        public CircularQueue(int capacity = 4)
        {
            elements = new T[capacity];
        }

        public int Count { get; private set; }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var value = elements[startIndex];

            elements[startIndex] = default;
            startIndex = (startIndex + 1) % elements.Length;

            Count--;

            return value;
        }

        public void Enqueue(T item)
        {
            if (Count >= elements.Length)
            {
                Grow();
            }
            elements[endIndex] = item;
            endIndex = (endIndex + 1) % elements.Length;
            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return elements[startIndex];
        }

        public T[] ToArray()
        {
            var elementsCopy = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                elementsCopy[i] = elements[(startIndex + i) % elements.Length];
            }

            return elementsCopy;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return elements[(startIndex + i) % elements.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private void Grow()
        {
            var elementsCopy = new T[elements.Length * 2];

            for (int i = 0; i < elements.Length; i++)
            {
                elementsCopy[i] = elements[(startIndex + i) % elements.Length];
            }

            startIndex = 0;
            endIndex = Count;
            elements = elementsCopy; 
        }
    }

}
