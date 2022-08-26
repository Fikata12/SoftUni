using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        private readonly List<string> collection;
        public AddCollection()
        {
            this.collection = new List<string>();
        }
        public int Add(string item)
        {
            collection.Add(item);
            return collection.Count - 1;
        }
    }
}
