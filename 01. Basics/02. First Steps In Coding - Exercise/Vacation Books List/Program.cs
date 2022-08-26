using System;

namespace Vacation_Books_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int bs = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            int bd = int.Parse(Console.ReadLine());
            Console.WriteLine(bs / s / bd);
        }   
    }
}
