using System;

namespace Number_100to200
{
    class Program
    {
        static void Main(string[] args)
        {
            int ch = int.Parse(Console.ReadLine());
            if (ch<100)
            {
                Console.WriteLine("Less than 100");
            }
             else if (ch>=100 && ch<=200)
            {
                Console.WriteLine("Between 100 and 200");
            }
             else if (ch>200)
            {
                Console.WriteLine("Greater than 200");
            }
        }
    }
}
