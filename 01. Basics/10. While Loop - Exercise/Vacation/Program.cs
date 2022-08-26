using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededmoney = double.Parse(Console.ReadLine());
            double ownedMoney = double.Parse(Console.ReadLine());
            int spendcounter = 0;
            bool isSaving = true;
            int daycounter = 0;
            while (neededmoney > ownedMoney)
            {
                string command = Console.ReadLine();            
                double money = double.Parse(Console.ReadLine());
                daycounter++;
                if (command == "spend")
                {
                    ownedMoney -= money;
                    spendcounter++;
                    if (ownedMoney < 0)
                    {
                        ownedMoney = 0;
                    }
                    if (spendcounter == 5)
                    {
                        isSaving = false;
                        break;
                    }
                }
                else if (command == "save")
                {
                    ownedMoney += money;
                    spendcounter = 0;
                }
            }
            if (isSaving)
            {
                Console.WriteLine($"You saved the money for {daycounter} days.");
            }
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(daycounter);
            }
        }
    }
}
