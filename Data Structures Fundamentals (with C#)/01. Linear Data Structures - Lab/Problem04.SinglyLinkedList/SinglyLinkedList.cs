namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

        public void AddFirst(T item)
        {
            head = new Node(item, head);
            Count++;
        }

        public void AddLast(T item)
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

        public T GetFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            return head.Element;
        }

        public T GetLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            var node = head;
            while (node.Next != null)
            {
                node = node.Next;
            }

            return node.Element;
        }

        public T RemoveFirst()
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

        public T RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            var element = head.Element;

            if (Count == 1)
            {
                head = null;
            }
            else
            {
                var node = head;
                while (node.Next?.Next != null)
                {
                    node = node.Next;
                }

                element = node.Next.Element;
                node.Next = null;
            }

            Count--;
            return element;
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