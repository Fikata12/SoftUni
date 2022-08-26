using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] NandM = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> setN = new HashSet<int>();
            HashSet<int> setM = new HashSet<int>();
            for (int i = 0; i < NandM[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setN.Add(num);
            }
            for (int i = 0; i < NandM[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setM.Add(num);
            }
            foreach (var item in setN)
            {
                if (setM.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
