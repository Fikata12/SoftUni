using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double totalPrice = 0;
            while (command != "Game Time")
            {
                double price = 0;
                switch (command)
                {
                    case "OutFall 4":
                         price = 39.99;
                        break;
                    case "CS: OG":
                         price = 15.99;
                        break;
                    case "Zplinter Zell":
                         price = 19.99;
                        break;
                    case "Honored 2":
                         price = 59.99;
                        break;
                    case "RoverWatch":
                         price = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                         price = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }
                if (price > 0)
                {
                    if (currentBalance >= price)
                    {
                        totalPrice += price;
                        currentBalance -= price;
                        Console.WriteLine($"Bought {command}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
              
                if (currentBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                }
                command = Console.ReadLine();
            }
            if (currentBalance > 0)
            {
                Console.WriteLine($"Total spent: ${totalPrice:f2}. Remaining: ${currentBalance:f2}");
            }
        }
    }
}
