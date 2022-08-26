using System;

namespace Number_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int ch = int.Parse(Console.ReadLine());
            if (ch >= -100 && ch <= 100 && ch != 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
