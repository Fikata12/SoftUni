using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Count => elements.Count;

        public void Add(T element)
        {
            elements.Add(element);
            HeapifyUp(Count - 1);
        }

        public void HeapifyUp(int index)
        {
            while (true)
            {
                var parentIndex = (index - 1) / 2;

                if (elements[parentIndex].CompareTo(elements[index]) > 0)
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

        public T ExtractMin()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var temp = elements[0];
            elements[0] = elements[Count - 1];
            elements[Count - 1] = temp;

            elements.RemoveAt(Count - 1);

            HeapifyDown(0);

            return temp;
        }

        private void HeapifyDown(int index)
        {
            var childIndex = SmallerChild(index);

            while (childIndex != -1 && elements[index].CompareTo(elements[childIndex]) > 0)
            {
                var temp = elements[childIndex];
                elements[childIndex] = elements[index];
                elements[index] = temp;
                index = childIndex;

                childIndex = SmallerChild(index);
            }
        }

        private int SmallerChild(int index)
        {
            var leftIndex = index * 2 + 1;
            var rightIndex = index * 2 + 2;

            if (Count < leftIndex + 1)
            {
                return -1;
            }

            if (Count < rightIndex + 1 || elements[leftIndex].CompareTo(elements[rightIndex]) <= 0)
            {
                return leftIndex;
            }

            return rightIndex;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return elements[0];
        }
    }
}
