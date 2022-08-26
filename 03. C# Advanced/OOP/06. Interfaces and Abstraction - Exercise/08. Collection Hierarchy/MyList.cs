using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IMyList
    {
        private readonly List<string> collection;
        public int Used => collection.Count;
        public MyList()
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
            string itemToRemove = collection.FirstOrDefault();
            collection.Remove(itemToRemove);
            return itemToRemove;
        }
    }
}
