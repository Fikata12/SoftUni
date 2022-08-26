using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int numberOfPieses = x * y;
            string pieces = Console.ReadLine();
            bool areLeft = true;
            while (pieces != "STOP")
            {
                if (numberOfPieses > Convert.ToInt32(pieces))
                {
                    numberOfPieses -= Convert.ToInt32(pieces);
                }
                else
                {
                    areLeft = false;
                    break;
                }
                pieces = Console.ReadLine();
            }

            if (areLeft)
            {
                Console.WriteLine($"{numberOfPieses} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Convert.ToInt32(pieces) - numberOfPieses} pieces more.");
            }

        }
    }
}
