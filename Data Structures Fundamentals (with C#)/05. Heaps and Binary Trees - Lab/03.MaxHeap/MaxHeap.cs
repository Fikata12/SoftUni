namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        List<T> elements;
        public int Size => elements.Count;

        public MaxHeap()
        {
            elements = new List<T>();
        }
        public void Add(T element)
        {
            elements.Add(element);
            HeapifyUp(elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            while (true)
            {
                var parentIndex = (index - 1) / 2;

                if (elements[parentIndex].CompareTo(elements[index]) < 0)
                {
                    var temp = elements[parentIndex];
                    elements[parentIndex] = elements[index];
                    elements[index] = temp;
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public T ExtractMax()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }

            var temp = elements[0];
            elements[0] = elements[Size - 1];
            elements[Size - 1] = temp;

            elements.RemoveAt(Size - 1);

            HeapifyDown(0);

            return temp;
        }

        private void HeapifyDown(int index)
        {
            var childIndex = GreaterChild(index);

            while (childIndex != -1 && elements[index].CompareTo(elements[childIndex]) < 0)
            {
                var temp = elements[childIndex];
                elements[childIndex] = elements[index];
                elements[index] = temp;
                index = childIndex;

                childIndex = GreaterChild(index);
            }
        }

        private int GreaterChild(int index)
        {
            var leftIndex = index * 2 + 1;
            var rightIndex = index * 2 + 2;

            if (Size < leftIndex + 1)
            {
                return -1;
            }

            if (Size < rightIndex + 1 || elements[leftIndex].CompareTo(elements[rightIndex]) >= 0)
            {
                return leftIndex;
            }

            return rightIndex;
        }

        public T Peek()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }

            return elements[0];
        }
    }
}
