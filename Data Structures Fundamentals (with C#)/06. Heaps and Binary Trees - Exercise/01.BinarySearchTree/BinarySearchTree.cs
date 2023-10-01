namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public BinarySearchTree()
        {
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            return node;
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = this.FindElement(element);

            return new BinarySearchTree<T>(current);
        }

        public void Delete(T element)
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            root = Delete(element, root);
        }

        private Node Delete(T element, Node node)
        {
            if (node == null)
            {
                return null;
            }

            if (element.CompareTo(node.Value) == 0)
            {
                if (node.Right == null && node.Left == null)
                {
                    return null;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }
                else if (node.Right != null)
                {
                    node.Value = FindTheLeftMostChild(node.Right).Value;
                    node.Right = DeleteMin(node.Right);
                }
            }
            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Delete(element, node.Left);
            }
            if (element.CompareTo(node.Value) > 0)
            {
                node.Right = Delete(element, node.Right);
            }
            return node;
        }

        private Node FindTheLeftMostChild(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        public void DeleteMax()
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            root = DeleteMax(root);
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = DeleteMax(node.Right);

            return node;
        }

        public void DeleteMin()
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            root = DeleteMin(root);
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = DeleteMin(node.Left);

            return node;
        }

        public int Count()
        {
            return Count(root);
        }

        private int Count(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int l = Count(node.Left);
            int r = Count(node.Right);

            return 1 + l + r;
        }

        public int Rank(T element)
        {
            return Rank(element, root);
        }

        private int Rank(T element, Node node)
        {
            if (node == null)
            {
                return 0;
            }

            var count = 0;

            if (element.CompareTo(node.Value) > 0)
            {
                count++;
            }

            count += Rank(element, node.Left);
            count += Rank(element, node.Right);

            return count;
        }

        public T Select(int rank)
        {
            var node = Select(rank, root);

            if (node == null)
            {
                throw new InvalidOperationException();
            }

            return node.Value;
        }

        private Node Select(int rank, Node node)
        {
            if (node == null)
            {
                return null;
            }

            int leftCount = Count(node.Left);

            if (leftCount == rank)
            {
                return node;
            }
            else if (leftCount > rank)
            {
                return Select(rank, node.Left);
            }
            else
            {
                return Select(rank - leftCount - 1, node.Right);
            }
        }

        public T Ceiling(T element)
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            return Ceiling(element, root);
        }

        private T Ceiling(T element, Node node)
        {
            T result = default;

            if (element.CompareTo(node.Value) < 0)
            {
                result = node.Value;
            }

            if (node.Left != null && element.CompareTo(node.Left.Value) <= 0)
            {
                result = Ceiling(element, node.Left);
            }

            if (node.Right != null && element.CompareTo(node.Right.Value) >= 0)
            {
                result = Ceiling(element, node.Right);
            }

            if (result.CompareTo(default(T)) == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public T Floor(T element)
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            return Floor(element, root);
        }

        private T Floor(T element, Node node)
        {
            T result = default;

            if (element.CompareTo(node.Value) > 0)
            {
                result = node.Value;
            }

            if (node.Left != null && element.CompareTo(node.Left.Value) >= 0)
            {
                result = Floor(element, node.Left);
            }

            if (node.Right != null && element.CompareTo(node.Right.Value) >= 0)
            {
                result = Floor(element, node.Right);
            }

            if (result.CompareTo(default(T)) == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            return Range(startRange, endRange, root);
        }

        private IEnumerable<T> Range(T startRange, T endRange, Node node)
        {
            List<T> result = new List<T>();

            if (node == null)
            {
                return result;
            }

            if (node.Value.CompareTo(startRange) > 0)
            {
                result.AddRange(Range(startRange, endRange, node.Left));
            }

            if (node.Value.CompareTo(startRange) >= 0 && node.Value.CompareTo(endRange) <= 0)
            {
                result.Add(node.Value);
            }

            if (node.Value.CompareTo(endRange) < 0)
            {
                result.AddRange(Range(startRange, endRange, node.Right));
            }

            return result;
        }

        private Node FindElement(T element)
        {
            Node current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }
    }
}
