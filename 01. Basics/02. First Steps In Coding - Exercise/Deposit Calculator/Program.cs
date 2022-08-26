using System;

namespace Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double dpzsm = double.Parse(Console.ReadLine());
            double srndp = double.Parse(Console.ReadLine());
            double glp = double.Parse(Console.ReadLine());
            Console.WriteLine(dpzsm + srndp * ((dpzsm * glp / 100) / 12));
        }
    }
}
