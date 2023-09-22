namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.children = new List<Tree<T>>();
            this.Key = key;

            foreach (var item in children)
            {
                AddChild(item);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => children;

        public void AddChild(Tree<T> child)
        {
            if (!children.Contains(child))
            {
                children.Add(child);
            }

            child.Parent = this;
        }

        public void AddParent(Tree<T> parent)
        {
            Parent = parent;

            if (!parent.children.Contains(this))
            {
                parent.children.Add(this);
            }
        }

        public string AsString()
        {
            StringBuilder sb = new StringBuilder();

            TreeAsStringBuilder(this, sb, 0);

            return sb.ToString().Trim();
        }

        public IEnumerable<T> GetInternalKeys()
        {
            List<T> list = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>(new[] { this });

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();

                if (element.children.Count != 0 && element.Parent != null)
                {
                    list.Add(element.Key);
                }

                foreach (var child in element.children)
                {
                    queue.Enqueue(child);
                }
            }

            return list;
        }

        public IEnumerable<T> GetLeafKeys()
        {
            List<T> list = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>(new[] { this });

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();

                if (element.children.Count == 0)
                {
                    list.Add(element.Key);
                }

                foreach (var child in element.children)
                {
                    queue.Enqueue(child);
                }
            }

            return list;
        }

        public T GetDeepestKey()
        {
            return GetDeepestNode(this, 0, this).Key;
        }

        public IEnumerable<T> GetLongestPath()
        {
            var deepest = GetDeepestNode(this, 0, this);

            Stack<Tree<T>> stack = new Stack<Tree<T>>();

            while (deepest != null)
            {
                stack.Push(deepest);
                deepest = deepest.Parent;
            }

            return stack.Select(e => e.Key);
        }

        private void TreeAsStringBuilder(Tree<T> tree, StringBuilder sb, int level)
        {
            sb.Append(' ', level * 2)
                .AppendLine(tree.Key.ToString());

            level++;

            foreach (var item in tree.Children)
            {
                TreeAsStringBuilder(item, sb, level);
            }
        }

        private Tree<T> GetDeepestNode(Tree<T> tree, int levelCounter, Tree<T> deepestNode)
        {

            if (levelCounter > GetLevel(deepestNode))
            {
                deepestNode = tree;
            }

            levelCounter++;

            foreach (var child in tree.children)
            {
                deepestNode = GetDeepestNode(child, levelCounter, deepestNode);
            }

            return deepestNode;
        }

        private int GetLevel(Tree<T> node)
        {
            var counter = 0;

            while (node.Parent != null)
            {
                counter++;
                node = node.Parent;
            }

            return counter;
        }
    }
}
