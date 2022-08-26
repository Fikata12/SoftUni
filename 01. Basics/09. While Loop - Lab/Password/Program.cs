using System;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string password = Console.ReadLine();
            string pass = "";
            while (password != pass)
            {
                pass = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {name}!");

        }
    }
}
