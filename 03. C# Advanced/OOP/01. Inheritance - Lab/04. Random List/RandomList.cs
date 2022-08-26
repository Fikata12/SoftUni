using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random randomIndex = new Random();
            int indexForRemoving = randomIndex.Next(0, this.Count);
            string removedItem = this[indexForRemoving];
            this.RemoveAt(randomIndex.Next(indexForRemoving));
            return removedItem;
        }
    }
}
