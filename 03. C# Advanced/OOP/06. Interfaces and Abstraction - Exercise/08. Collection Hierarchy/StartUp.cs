using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IAddCollection> allCollections = new List<IAddCollection>
            {
                new AddCollection(),
                new AddRemoveCollection(),
                new MyList()
            };
            string[] elementsToAdd = Console.ReadLine().Split();
            foreach (var item in allCollections)
            {
                foreach (var element in elementsToAdd)
                {
                    Console.Write(item.Add(element) + " ");
                }
                Console.WriteLine();
            }
            int numberOfOperations = int.Parse(Console.ReadLine());
            foreach (var item in allCollections.FindAll(c => c as IAddRemoveCollection != null))
            {
                IAddRemoveCollection addRemoveCollection = item as IAddRemoveCollection;
                for (int i = 0; i < numberOfOperations; i++)
                {
                    Console.Write(addRemoveCollection.Remove() + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
