using System;

namespace Lunch_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int duration = int.Parse(Console.ReadLine());
            int breakdur = int.Parse(Console.ReadLine());
            double a = 1 / 8 * breakdur;
            double b = 1.00 / 4 * breakdur;
            double time = breakdur - a - b;

            if (time >= duration)
            {
                double lefttime = Math.Ceiling(time - duration);
                Console.WriteLine($"You have enough time to watch {name} and left with {lefttime} minutes free time.");
            }
            else
            {
                double neededtime = Math.Ceiling(duration - time);
                Console.WriteLine($"You don't have enough time to watch {name}, you need {neededtime} more minutes.");
            }
        }
    }
}
