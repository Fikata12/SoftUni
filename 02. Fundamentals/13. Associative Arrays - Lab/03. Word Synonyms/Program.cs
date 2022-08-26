using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int theCountOfTheWords = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();
            for (int i = 0; i < theCountOfTheWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!words.ContainsKey(word))
                {
                    words.Add(word, new List<string>());
                    words[word].Add(synonym);
                }
                else
                {
                    words[word].Add(synonym);
                }
            }
            foreach (KeyValuePair<string, List<string>> word in words)
            {
                Console.WriteLine($"{word.Key} - {String.Join(", ", word.Value)}");
            }           
        }
    }
}
