namespace Tree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;

        private Tree<T> parent;

        private List<Tree<T>> children;

        public Tree(T value)
        {
            children = new List<Tree<T>>();
            this.value = value;
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parent = FindNodeBfs(parentKey);
            parent.children.Add(child);
        }

        public IEnumerable<T> OrderBfs()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>(new[] { this });
            List<T> elements = new List<T>();

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();
                elements.Add(element.value);

                foreach (var child in element.children)
                {
                    queue.Enqueue(child);
                }
            }

            return elements;
        }

        public IEnumerable<T> OrderDfs()
        {
            Stack<Tree<T>> stack = new Stack<Tree<T>>(new[] { this });
            Stack<T> elements = new Stack<T>();
            while (stack.Count > 0)
            {
                var element = stack.Pop();
                elements.Push(element.value);

                foreach (var child in element.children)
                {
                    stack.Push(child);
                }
            }

            return elements;
        }

        public void RemoveNode(T nodeKey)
        {
            var node = FindNodeBfs(nodeKey);

            if (node == this)
            {
                throw new ArgumentException(nameof(nodeKey));
            }

            node.parent.children.Remove(node);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = FindNodeBfs(firstKey);
            var secondNode = FindNodeBfs(secondKey);

            if (firstNode.parent == null || secondNode.parent == null)
            {
                throw new ArgumentException();
            }

            var indexOfFirstNode = firstNode.parent.children.IndexOf(firstNode);
            var indexOfSecondNode = secondNode.parent.children.IndexOf(secondNode);

            firstNode.parent.children[indexOfFirstNode] = secondNode;
            secondNode.parent.children[indexOfSecondNode] = firstNode;

            secondNode.parent = firstNode.parent;
            firstNode.parent = secondNode.parent;
        }

        private Tree<T> FindNodeBfs(T key)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>(new[] { this });

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();

                if (element.value.Equals(key))
                {
                    return element;
                }

                foreach (var item in element.children)
                {
                    queue.Enqueue(item);
                }
            }

            throw new ArgumentNullException(nameof(key));
        }
    }
}
