namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            List<List<int>> paths = new List<List<int>>();

            FindPathsWithGivenSum(this, paths, new List<int>(), sum);

            return paths;
        }
        private void FindPathsWithGivenSum(Tree<int> tree, List<List<int>> paths, List<int>currentPath, int sum)
        {
            currentPath.Add(tree.Key);

            foreach (var child in tree.Children)
            {
                FindPathsWithGivenSum(child, paths, currentPath, sum);
            }

            if (currentPath.Sum() == sum && tree.Children.Count == 0)
            {
                paths.Add(new List<int>(currentPath));
            }

            currentPath.RemoveAt(currentPath.Count - 1);
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            List<Tree<int>> subtrees = new List<Tree<int>>();
            Queue<Tree<int>> queue = new Queue<Tree<int>>(new[] { this });

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();

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


                foreach (var child in element.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return subtrees;
        }
    }
}
