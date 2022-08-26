using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            while (destination != "End")
            {
                double neededMoney = double.Parse(Console.ReadLine());
                double sum = 0;
                while (sum < neededMoney) 
                {
                    sum += double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {destination}!");           
                destination = Console.ReadLine();                
            }
        }
    }
}
