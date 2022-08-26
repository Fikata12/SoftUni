using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> letters = new Dictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (letters.ContainsKey(text[i]))
                {
                    letters[text[i]] += 1;
                }
                else
                {
                    letters.Add(text[i], 1);
                }
            }
            foreach (var item in letters.Where(x => x.Key != ' '))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
