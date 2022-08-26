using System;

namespace Projects_Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            string archname = Console.ReadLine();
            int numprojects =int.Parse(Console.ReadLine());
            
            Console.WriteLine($"The architect {archname} will need {numprojects * 3} hours to complete {numprojects} project/s.");
        }
    }
}
