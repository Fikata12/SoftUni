using System;

namespace Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double academypoints = double.Parse(Console.ReadLine());
            int njury = int.Parse(Console.ReadLine());
            for (int i = 0; i < njury; i++)
            {
                string juryname = Console.ReadLine();
                double jurypoints = double.Parse(Console.ReadLine());              
                academypoints += juryname.Length * jurypoints / 2;
                if (academypoints > 1250.5)
                {
                    break;
                }
            }
            if (academypoints > 1250.5)
            {
                Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {academypoints:f1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {name} you need {1250.5 - academypoints:f1} more!");
                
            }
        }
    }
}
