using System;

namespace Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int broi = int.Parse(Console.ReadLine());
            int leftsum = 0;
            int rightsum = 0;

            for (int i = 0; i < broi; i++)
            {
                leftsum += int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < broi; i++)
            {
                rightsum += int.Parse(Console.ReadLine());
            }

            if (rightsum == leftsum)
            {
                Console.WriteLine($" Yes, sum = {leftsum}");
            }
            else if (rightsum != leftsum)
            {
                Console.WriteLine($" No, diff = {Math.Abs(rightsum - leftsum)}");
            }
        }
    }
}
