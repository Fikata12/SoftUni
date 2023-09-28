namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        private Node root;

        public BinarySearchTree()
        {
                
        }
        private BinarySearchTree(Node node)
        {
            root = node;
        }

        public bool Contains(T element)
        {
            return Contains(element, root);
        }

        private bool Contains(T element, Node node)
        {
            bool contains;

            if (node == null)
            {
                return false;
            }
            else if (element.CompareTo(node.Value) == 0)
            {
                return true;
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                contains = Contains(element, node.Left);
            }
            else
            {
                contains = Contains(element, node.Right);
            }

            return contains;
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(action, root);
        }
        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            EachInOrder(action, node.Left);

            action(node.Value);

            EachInOrder(action, node.Right);
        }

        public void Insert(T element)
        {
            root = Insert(element, root);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) >= 0)
            {
                node.Right = Insert(element, node.Right);
            }

            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = Search(element, root);

            if (node == null)
            {
                return null;
            }

            return new BinarySearchTree<T>(node);
        }

        private Node Search(T element, Node node)
        {
            Node foundNode = null;

            if (node == null)
            {
                return null;
            }
            else if (element.CompareTo(node.Value) == 0)
            {
                return node;
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                foundNode = Search(element, node.Left);
            }
            else if (element.CompareTo(node.Value) >= 0)
            {
                foundNode = Search(element, node.Right);
            }

            return foundNode;
        }

        private class Node
        {
            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }
    }
}
