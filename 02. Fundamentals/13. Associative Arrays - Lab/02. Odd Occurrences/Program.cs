using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sequence = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dictionary<string, int> a = new Dictionary<string, int>();
            foreach (string word in sequence)
            {
                if (!a.ContainsKey(word))
                {
                    a.Add(word, 1);                   
                }
                else
                {
                    a[word] += 1;
                }
            }
            List<string> b = new List<string>();

            foreach (KeyValuePair<string, int> item in a)
            {
                if (item.Value % 2 != 0)
                {
                    b.Add(item.Key);
               }
            }

            Console.WriteLine(String.Join(' ', b));
        }
    }
}
