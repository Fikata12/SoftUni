using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            string input = Console.ReadLine();
            while (input != "PARTY")
            {
                guests.Add(input);
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "END")
            {
                if (guests.Contains(input))
                {
                    guests.Remove(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(guests.Count);
            foreach (var guest in guests)
            {
                char[] ch = guest.ToCharArray();
                if (char.IsDigit(ch[0]))
                {
                    Console.WriteLine(guest);
                }
            }
            foreach (var item in guests)
            {
                char[] ch = item.ToCharArray();
                if (char.IsLetter(ch[0]))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}