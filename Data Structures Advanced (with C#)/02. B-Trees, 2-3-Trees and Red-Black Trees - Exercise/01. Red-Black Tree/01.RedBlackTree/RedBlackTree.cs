using System;

namespace _01.RedBlackTree
{
    public class RedBlackTree<T> where T : IComparable
    {
        const bool Red = true;
        const bool Black = false;

        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Color = Red;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public bool Color { get; set; }
        }

        public Node root;
        private RedBlackTree(Node node)
        {
            PreOrderCopy(node);
        }

        public RedBlackTree()
        {

        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            Insert(node.Value);
            PreOrderCopy(node.Left);
            PreOrderCopy(node.Right);
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(root, action);
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

        public RedBlackTree<T> Search(T element)
        {
            Node current = FindNode(element);

            return new RedBlackTree<T>(current);
        }

        private Node FindNode(T element)
        {
            var current = root;

            while (current != null)
            {
                if (IsLess(element, current.Value))
                {
                    current = current.Left;
                }
                else if (IsLess(current.Value, element))
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

        public void Insert(T element)
        {
            root = Insert(root, element);
            root.Color = Black;
        }

        private Node Insert(Node node, T element)
        {
            if (node == null)
            {
                return new Node(element);
            }

            if (IsLess(element, node.Value))
            {
                node.Left = Insert(node.Left, element);
            }
            else
            {
                node.Right = Insert(node.Right, element);
            }

            if (IsRed(node.Right))
            {
                node = RotateLeft(node);
            }
            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }
            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColor(node);
            }

            return node;
        }

        public void Delete(T element)
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            root = Delete(root, element);

            if (root != null)
            {
                root.Color = Black;
            }
        }

        private Node Delete(Node node, T element)
        {
            if (IsLess(element, node.Value))
            {
                if (!IsRed(node.Left) && !IsRed(node.Left.Left))
                {
                    node = MoveRedLeft(node);
                }

                node.Left = Delete(node.Left, element);
            }
            else
            {
                if (IsRed(node.Left))
                {
                    node = RotateRight(node);
                }

                if (AreEqual(node.Value, element) && node.Right == null)
                {
                    return null;
                }

                if (!IsRed(node.Right) && !IsRed(node.Right.Left))
                {
                    node = MoveRedRight(node);
                }

                if (AreEqual(node.Value, element))
                {
                    node.Value = FindMinimumValueInSubtree(node.Right);
                    node.Right = DeleteMin(node.Right);
                }
                else
                {
                    node.Right = Delete(node.Right, element);
                }
            }

            return FixUp(node);
        }

        private T FindMinimumValueInSubtree(Node node)
        {
            if (node.Left == null)
            {
                return node.Value;
            }

            return FindMinimumValueInSubtree(node.Left);
        }

        public void DeleteMin()
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            root = DeleteMin(root);

            if (root != null)
            {
                root.Color = Black;
            }
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return null;
            }

            if (!IsRed(node.Left) && !IsRed(node.Left.Left))
            {
                node = MoveRedLeft(node);
            }

            node.Left = DeleteMin(node.Left);

            return FixUp(node);
        }

        public void DeleteMax()
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            root = DeleteMax(root);

            if (root != null)
            {
                root.Color = Black;
            }
        }

        private Node DeleteMax(Node node)
        {
            if (IsRed(node.Left))
            {
                node = RotateRight(node);
            }

            if (node.Right == null)
            {
                return null;
            }

            if (!IsRed(node.Right) && !IsRed(node.Right.Left))
            {
                node = MoveRedRight(node);
            }

            node.Right = DeleteMax(node.Right);

            return FixUp(node);
        }

        private Node FixUp(Node node)
        {
            if (IsRed(node.Right))
            {
                node = RotateLeft(node);
            }
            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }
            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColor(node);
            }

            return node;
        }

        private Node MoveRedLeft(Node node)
        {
            FlipColor(node);

            if (IsRed(node.Right.Left))
            {
                node.Right = RotateRight(node.Right);
                node = RotateLeft(node);
                FlipColor(node);
            }

            return node;
        }

        private Node MoveRedRight(Node node)
        {
            FlipColor(node);

            if (IsRed(node.Left.Left))
            {
                node = RotateRight(node);
                FlipColor(node);
            }

            return node;
        }

        public int Count()
        {
            return Count(root);
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
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

        private int Count(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Count(node.Left) + Count(node.Right);
        }

        private Node RotateLeft(Node node)
        {
            var temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;
            temp.Color = temp.Left.Color; 
            temp.Left.Color = Red;
            
            return temp;
        }

        private Node RotateRight(Node node)
        {
            var temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;
            temp.Color = temp.Right.Color;
            temp.Right.Color = Red;

            return temp;
        }

        private void FlipColor(Node node)
        {
            node.Color = !node.Color;
            node.Left.Color = !node.Left.Color;
            node.Right.Color = !node.Right.Color;
        }

        private bool IsRed(Node node)
        {
            if (node == null)
            {
                return false;
            }

            return node.Color == Red;
        }

        private bool IsLess(T a, T b)
        {
            return a.CompareTo(b) < 0;
        }

        private bool AreEqual(T a, T b)
        {
            return a.CompareTo(b) == 0;
        }
    }
}