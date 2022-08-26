using System;

namespace Invalid_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int ch = int.Parse(Console.ReadLine());
            if (ch != 0 && ch < 100 || ch > 200 && ch != 0)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
