namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            List<Tree<int>> pathEnds = new List<Tree<int>>();

            FindEndOfPathsWithGivenSum(this, pathEnds, sum);

            List<Stack<int>> paths = new List<Stack<int>>();

            foreach (var pathEnd in pathEnds)
            {
                paths.Add(new Stack<int>());

                var node = pathEnd;

                while (node != null)
                {
                    paths[paths.Count - 1].Push(node.Key);
                    node = node.Parent;
                }
            }

            return paths;
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            List<Tree<int>> subtrees = new List<Tree<int>>();
            Queue<Tree<int>> queue = new Queue<Tree<int>>(new[] { this });

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();

                if (element.Parent != null)
                {
                    int currentSum = 0;
                    Queue<Tree<int>> innerQueue = new Queue<Tree<int>>(new[] { element });

                    while (innerQueue.Count > 0)
                    {
                        var innerElement = innerQueue.Dequeue();

                        currentSum += innerElement.Key;

                        foreach (var child in innerElement.Children)
                        {
                            innerQueue.Enqueue(child);
                        }
                    }

                    if (currentSum == sum)
                    {
                        subtrees.Add(element);
                    }
                }

                foreach (var child in element.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return subtrees;
        }

        private void FindEndOfPathsWithGivenSum(Tree<int> tree, List<Tree<int>> pathEnds, int sum, int currentSum = 0)
        {
            currentSum += tree.Key;

            foreach (var child in tree.Children)
            {
                FindEndOfPathsWithGivenSum(child, pathEnds, sum, currentSum);
            }

            if (currentSum == sum && tree.Children.Count == 0)
            {
                pathEnds.Add(tree);
            }
        }
    }
}
