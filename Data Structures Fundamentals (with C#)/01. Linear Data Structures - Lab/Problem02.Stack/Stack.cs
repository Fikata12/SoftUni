namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class Stack<T> : IAbstractStack<T>
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

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            var node = new Node(item, top);
            top = node;
            Count++;
        }

        public T Pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException();
            }

            var element = top.Element;
            top = top.Next;
            Count--;
            return element;
        }

        public T Peek()
        {
            if (top == null)
            {
                throw new InvalidOperationException();
            }

            return top.Element;
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
            Node nextNode = top;
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