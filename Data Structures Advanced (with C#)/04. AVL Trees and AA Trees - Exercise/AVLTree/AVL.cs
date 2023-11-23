namespace AVLTree
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Height = 1;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }
        }

        public Node Root { get; private set; }

        public bool Contains(T item)
        {
            return Contains(Root, item) != null;
        }

        private Node Contains(Node node, T element)
        {
            if (node == null)
            {
                return null;
            }
            var compare = element.CompareTo(node.Value);

            if (compare < 0)
            {
                return Contains(node.Left, element);
            }
            else if (compare > 0)
            {
                return Contains(node.Right, element);
            }

            return node;
        }

        public void Delete(T element)
        {
            Root = Delete(Root, element);
        }

        private Node Delete(Node node, T element)
        {
            if (node == null)
            {
                return null;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Delete(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = Delete(node.Right, element);
            }
            else
            {
                if (node.Left == null && node.Right == null)
                {
                    return null;
                }
                else if (node.Left == null)
                {
                    node = node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                else
                {
                    Node temp = FindSmallestChild(node.Right);
                    node.Value = temp.Value;

                    node.Right = Delete(node.Right, temp.Value);
                }
            }

            node = Balance(node);
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

            return node;
        }

        private Node FindSmallestChild(Node node)
        {
            if (node.Left == null)
            {
                return node;
            }

            return FindSmallestChild(node.Left);
        }

        public void DeleteMin()
        {
            if (Root == null)
            {
                return;
            }

            var temp = FindSmallestChild(Root);
            Root = Delete(Root, temp.Value);
        }

        public void Insert(T element)
        {
            Root = Insert(Root, element);
        }

        private Node Insert(Node node, T element)
        {
            if (node == null)
            {
                return new Node(element);
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left, element);
            }
            else
            {
                node.Right = Insert(node.Right, element);
            }

            node = Balance(node);
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

            return node;
        }

        private Node Balance(Node node)
        {
            var balanceFactor = Height(node.Left) - Height(node.Right);

            if (balanceFactor > 1)
            {
                var childBalanceFactor = Height(node.Left.Left) - Height(node.Left.Right);
                if (childBalanceFactor < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                node = RotateRight(node);
            }
            else if (balanceFactor < -1)
            {
                var childBalanceFactor = Height(node.Right.Left) - Height(node.Right.Right);
                if (childBalanceFactor > 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                node = RotateLeft(node);
            }

            return node;
        }

        private Node RotateRight(Node node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

            return left;
        }

        private Node RotateLeft(Node node)
        {
            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

            return right;
        }

        private int Height(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(Root, action);
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (Root == null)
            {
                return;
            }
            EachInOrder(node.Left, action);
            action(node.Value);
            EachInOrder(node.Right, action);
        }
    }
}
