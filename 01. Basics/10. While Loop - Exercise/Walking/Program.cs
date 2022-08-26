using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string steps = Console.ReadLine();
            int total = 0;
            while (total < 10000) 
            {
                if (steps == "Going home")
                {
                    steps = Console.ReadLine();
                    total += Convert.ToInt32(steps);
                    break;
                }
                else
                {
                    total += Convert.ToInt32(steps);
                }
                steps = Console.ReadLine();
            }
            if (total < 10000) 
            {
                Console.WriteLine($"{10000 - total} more steps to reach goal.");
            }
            else
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{total - 10000} steps over the goal!");
            }
        }
    }
}
