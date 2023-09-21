namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public IntegerTreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var parentKey = int.Parse(input[i].Split()[0]);
                var childKey = int.Parse(input[i].Split()[1]);

                if (!nodesByKey.ContainsKey(parentKey))
                {
                    CreateNodeByKey(parentKey);
                }

                if (!nodesByKey.ContainsKey(childKey))
                {
                    CreateNodeByKey(childKey);
                }

                AddEdge(parentKey, childKey);
            }

            return GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            var node = new IntegerTree(key);
            nodesByKey.Add(key, node);
            return node;
        }

        public void AddEdge(int parent, int child)
        {
            nodesByKey[parent].AddChild(nodesByKey[child]);
            nodesByKey[child].AddParent(nodesByKey[parent]);
        }

        public IntegerTree GetRoot()
        {
            return nodesByKey.FirstOrDefault(n => n.Value.Parent == null).Value;
        }
    }
}
