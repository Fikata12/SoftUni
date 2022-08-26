using System;

namespace Working_Hours
{
    class Program
    {
        static void Main(string[] args)
        {
            int ch = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday" || day == "Saturday")
            {
                if (ch >= 10 && ch <= 18)
                {
                    Console.WriteLine("open");
                }
                else
                {
                    Console.WriteLine("closed");
                }
            }
            else if (day == "Sunday")
            {
                Console.WriteLine("closed");
            }
        }
    }
}