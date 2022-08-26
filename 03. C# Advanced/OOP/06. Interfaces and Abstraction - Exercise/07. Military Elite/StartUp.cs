using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();
            List<Soldier> military = new List<Soldier>();
            while (cmd != "End")
            {
                string[] cmdToArray = cmd.Split().ToArray();
                switch (cmdToArray[0])
                {
                    case "Private":
                        military.Add(new Private(cmdToArray[1], cmdToArray[2], cmdToArray[3], decimal.Parse(cmdToArray[4])));
                        break;
                    case "Spy":
                        military.Add(new Spy(cmdToArray[1], cmdToArray[2], cmdToArray[3], int.Parse(cmdToArray[4])));
                        break;
                    case "LieutenantGeneral":
                        Queue<string> input = new Queue<string>(cmdToArray.Skip(5).ToList());
                        List<Private> @privates = new List<Private>();
                        while (input.Count > 0)
                        {
                            @privates.Add(military.FirstOrDefault(s => s.Id == input.Peek()) as Private);
                            input.Dequeue();
                        }
                        military.Add(new LieutenantGeneral(cmdToArray[1], cmdToArray[2], cmdToArray[3], decimal.Parse(cmdToArray[4]), privates));
                        break;
                    case "Engineer":
                        if (cmdToArray[5] == "Marines" || cmdToArray[5] == "Airforces")
                        {
                            input = new Queue<string>(cmdToArray.Skip(6).ToList());
                            List<Repair> repairs = new List<Repair>();
                            while (input.Count > 0)
                            {
                                repairs.Add(new Repair(input.Dequeue(), int.Parse(input.Dequeue())));
                            }
                            military.Add(new Engineer(cmdToArray[1], cmdToArray[2], cmdToArray[3], cmdToArray[5], decimal.Parse(cmdToArray[4]), repairs));
                        }
                        break;
                    case "Commando":
                        List<Mission> missions = new List<Mission>();
                        input = new Queue<string>(cmdToArray.Skip(6).ToList());
                        while (input.Count > 0)
                        {
                            missions.Add(new Mission(input.Dequeue(), input.Dequeue()));
                        }
                        military.Add(new Commando(cmdToArray[1], cmdToArray[2], cmdToArray[3], cmdToArray[5], decimal.Parse(cmdToArray[4]), missions));
                        break;
                }
                cmd = Console.ReadLine();
            }
            foreach (var soldier in military)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}