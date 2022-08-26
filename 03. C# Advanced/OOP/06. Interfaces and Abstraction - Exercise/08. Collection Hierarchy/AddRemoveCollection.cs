using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy
{
    internal class AddRemoveCollection : IAddRemoveCollection
    {
        private readonly List<string> collection;
        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }
        public int Add(string item)
        {
            collection.Insert(0, item);
            return 0;
        }
        public string Remove()
        {
            string itemToRemove = collection.LastOrDefault();
            collection.Remove(itemToRemove);
            return itemToRemove;
        }
    }
}
