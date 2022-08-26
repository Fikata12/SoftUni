using System;

namespace _04._Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            hours *= 60;
            int hoursAndMinutes = hours + minutes + 30;
            hours = hoursAndMinutes / 60;
            minutes = hoursAndMinutes % 60;
            if (hours == 24)
            {
                hours = 0;
            }

            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}
