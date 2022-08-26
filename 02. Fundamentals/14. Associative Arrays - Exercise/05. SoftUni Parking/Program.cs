using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SoftUni_Parking
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Dictionary<string, string> parkingRegister =
                   new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];
                string username = cmdArgs[1];

                if (cmdType == "register")
                {
                    string licensePlateNumber = cmdArgs[2];

                    if (parkingRegister.ContainsKey(username))
                    {
                        string licenseNumberRegistered = parkingRegister[username];
                        Console.WriteLine($"ERROR: already registered with plate number {licenseNumberRegistered}");
                    }
                    else
                    {
                        parkingRegister[username] = licensePlateNumber;
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }
                else if (cmdType == "unregister")
                {
                    if (!parkingRegister.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        parkingRegister.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var kvp in parkingRegister)
            {
                string username = kvp.Key;
                string licensePlateNumber = kvp.Value;

                Console.WriteLine($"{username} => {licensePlateNumber}");
            }
        }
    }
}
