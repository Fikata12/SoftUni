using System;
using System.Linq;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split().ToArray();
            Array.Reverse(a);
            Console.WriteLine(string.Join(" ", a));
        }
    }
}
