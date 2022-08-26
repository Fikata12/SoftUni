using System;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            string money = Console.ReadLine();
            double a = 0;
            while (money != "NoMoreMoney")
            {

                if (Convert.ToDouble(money) >= 0) 
                {
                    a += Convert.ToDouble(money);
                    Console.WriteLine($"Increase: {Convert.ToDouble(money):f2}");
                    money = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
            }
            Console.WriteLine($"Total: {a:f2}");
        }
    }
}
