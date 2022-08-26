using System;

namespace Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            if (fruit == "banana")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    Console.WriteLine($"{quantity * 2.5:f2}");
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    Console.WriteLine($"{quantity * 2.7:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (fruit == "apple")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    Console.WriteLine($"{quantity * 1.20:f2}");
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    Console.WriteLine($"{quantity * 1.25:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (fruit == "orange")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    Console.WriteLine($"{quantity * 0.85:f2}");
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    Console.WriteLine($"{quantity * 0.90:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (fruit == "grapefruit")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    Console.WriteLine($"{quantity * 1.45:f2}");
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    Console.WriteLine($"{quantity * 1.60:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (fruit == "kiwi")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    Console.WriteLine($"{quantity * 2.70:f2}");
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    Console.WriteLine($"{quantity * 3:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (fruit == "pineapple")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    Console.WriteLine($"{quantity * 5.50:f2}");
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    Console.WriteLine($"{quantity * 5.60:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (fruit == "grapes")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    Console.WriteLine($"{quantity * 3.85:f2}");
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    Console.WriteLine($"{quantity * 4.20:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
