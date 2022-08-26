
using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            const double videoCard = 250;
            const double processor = videoCard * 0.35;
            const double ram = videoCard * 0.10;

            double budget = double.Parse(Console.ReadLine());
            int videoCardB = int.Parse(Console.ReadLine());
            int processorB = int.Parse(Console.ReadLine());
            int ramB = int.Parse(Console.ReadLine());

            double cenaVideoCard = videoCard * videoCardB;
            double cenaProcessor = processor * videoCardB * processorB;
            double cenaRam = ram * ramB;

            double price = cenaVideoCard + cenaProcessor + cenaRam;

            if (videoCardB > processorB)
            {
                price = price - 0.15 * price;
            }

            Console.WriteLine(price <= budget ? $"You have {budget - price:F2} leva left!" : $"Not enough money! You need {price - budget:F2} leva more!");
        }
    }
}