namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            Value = element;
            LeftChild = left;
            RightChild = right;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            StringBuilder sb = new StringBuilder();

            PreOrderDfs(sb, indent, this);

            return sb.ToString().Trim();
        }

        private void PreOrderDfs(StringBuilder sb, int indent, IAbstractBinaryTree<T> binaryTree, int levelCounter = 0)
        {
            sb.Append(' ', indent * levelCounter)
                .AppendLine(binaryTree.Value.ToString());

            levelCounter++;

            if (binaryTree.LeftChild != null)
            {
                PreOrderDfs(sb, indent, binaryTree.LeftChild, levelCounter);
            }

            if (binaryTree.RightChild != null)
            {
                PreOrderDfs(sb, indent, binaryTree.RightChild, levelCounter);
            }
        }

        public void ForEachInOrder(Action<T> action)
        {
            InOrderDfs(this, action);
        }

        private void InOrderDfs(IAbstractBinaryTree<T> binaryTree, Action<T> action)
        {

            if (binaryTree.LeftChild != null)
            {
                InOrderDfs(binaryTree.LeftChild, action);
            }

            action(binaryTree.Value);

            if (binaryTree.RightChild != null)
            {
                InOrderDfs(binaryTree.RightChild, action);
            }
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            if (LeftChild != null)
            {
                result.AddRange(LeftChild.InOrder());
            }

            result.Add(this);

            if (RightChild != null)
            {
                result.AddRange(RightChild.InOrder());
            }

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            if (LeftChild != null)
            {
                result.AddRange(LeftChild.PostOrder());
            }

            if (RightChild != null)
            {
                result.AddRange(RightChild.PostOrder());
            }

            result.Add(this);

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            result.Add(this);

            if (LeftChild != null)
            {
                result.AddRange(LeftChild.PreOrder());
            }

            if (RightChild != null)
            {
                result.AddRange(RightChild.PreOrder());
            }

            return result;
        }
    }
}
