using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;
            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }
            int tryCounter = 0;
            while (tryCounter < 4)
            {
                string input = Console.ReadLine();
                tryCounter++;
                if (input == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    return;
                }
                else if (tryCounter != 4)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }              
            }
            Console.WriteLine($"User {username} blocked!");
        }
    }
}
