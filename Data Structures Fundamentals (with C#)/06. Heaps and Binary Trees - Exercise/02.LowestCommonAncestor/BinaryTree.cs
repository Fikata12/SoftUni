namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;

            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            BinaryTree<T> firstElement = FindDfs(first);
            BinaryTree<T> secondElement = FindDfs(second);

            List<BinaryTree<T>> firstElementAncestors = new List<BinaryTree<T>>();

            var firstElementParent = firstElement;
            while (firstElementParent != null)
            {
                firstElementAncestors.Add(firstElementParent);
                firstElementParent = firstElementParent.Parent;
            }

            var secondElementParent = secondElement;
            while (secondElementParent != null)
            {
                if (firstElementAncestors.Contains(secondElementParent))
                {
                    return secondElementParent.Value;
                }
                secondElementParent = secondElementParent.Parent;
            }

            throw new InvalidOperationException();
        }

        private BinaryTree<T> FindDfs(T value)
        {
            Stack<BinaryTree<T>> stack = new Stack<BinaryTree<T>>(new[] { this });
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (value.CompareTo(node.Value) == 0)
                {
                    return node;
                }

                if (node.RightChild != null)
                {
                    stack.Push(node.RightChild);
                }
                if (node.LeftChild != null)
                {
                    stack.Push(node.LeftChild);
                }
            }
            return null;
        }
    }
}
