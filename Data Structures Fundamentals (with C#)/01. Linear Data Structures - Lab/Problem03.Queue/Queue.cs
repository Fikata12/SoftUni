namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }

            public Node(T element) : this(element, null)
            {
            }
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (head == null)
            {
                head = new Node(item);
                Count++;
                return;
            }
            var node = head;
            while (node.Next != null)
            {
                node = node.Next;
            }

            node.Next = new Node(item);
            Count++;
        }

        public T Dequeue()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            var element = head.Element;
            head = head.Next;
            Count--;
            return element;
        }

        public T Peek()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            return head.Element;
        }

        public bool Contains(T item)
        {
            foreach (var node in this)
            {
                if (node.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node nextNode = head;
            while (nextNode != null)
            {
                yield return nextNode.Element;
                nextNode = nextNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}