using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr1 = new int[n];
            int[] arr2 = new int[n];
            int where = 1;
            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (where == 1)
                {
                    arr1[i] = arr[0];
                    arr2[i] = arr[1];
                    where = 2;
                }
                else
                {
                    arr2[i] = arr[0];
                    arr1[i] = arr[1];
                    where = 1;
                }
            }
            Console.WriteLine(String.Join(' ', arr1));
            Console.WriteLine(String.Join(' ', arr2));
        }
    }
}
