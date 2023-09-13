namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Previous { get; set; }
            public Node Next { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }

        private Node head;

        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newHead = new Node(item);

            if (head == null && tail == null)
            {
                head = newHead;
                tail = newHead;
            }
            else
            {
                newHead.Next = head;
                head.Previous = newHead;
                head = newHead;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            var newTail = new Node(item);

            if (head == null && tail == null)
            {
                head = newTail;
                tail = newTail;
            }
            else
            {
                newTail.Previous = tail;
                tail.Next = newTail;
                tail = newTail;
            }

            Count++;
        }

        public T GetFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return head.Value;
        }

        public T GetLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return tail.Value;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var value = head.Value;

            if (Count == 1)
            {
                tail = head = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }

            Count--;
            return value;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var value = tail.Value;

            if (Count == 1)
            {
                tail = head = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }

            Count--;
            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var nextNode = head;
            while (nextNode != null)
            {
                yield return nextNode.Value;
                nextNode = nextNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}