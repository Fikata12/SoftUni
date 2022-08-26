using System;

namespace Speed_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            double sp = double.Parse(Console.ReadLine());

            if (sp <= 10)
            {
                Console.WriteLine("slow");
            }
            else if (sp>10 && sp<=50)
            {
                Console.WriteLine("average");
            }
            else if (sp>50 && sp<=150)
            {
                Console.WriteLine("fast");
            }
            else if (sp>150 && sp<=1000)
            {
                Console.WriteLine("ultra fast");
            }
            else
            {
                Console.WriteLine("extremely fast"); 
            }
        }
    }
}
