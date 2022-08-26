using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int cubicMeters = a * b * c;

            string numberOfBoxes = Console.ReadLine();
            bool areLeft = true;
            while (numberOfBoxes != "Done")
            {
                if (cubicMeters > Convert.ToInt32(numberOfBoxes))
                {
                    cubicMeters -= Convert.ToInt32(numberOfBoxes);
                }
                else
                {
                    areLeft = false;
                    break;
                }
                numberOfBoxes = Console.ReadLine();
            }

            if (areLeft)
            {
                Console.WriteLine($"{cubicMeters} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {Convert.ToInt32(numberOfBoxes) - cubicMeters} Cubic meters more.");
            }
        }
    }
}
