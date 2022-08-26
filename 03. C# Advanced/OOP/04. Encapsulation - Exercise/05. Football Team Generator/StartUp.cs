using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeam
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Team> teams = new List<Team>();
            while (input != "END")
            {
                string[] inputArray = input.Split(';').ToArray();
                string cmd = inputArray[0];
                try
                {
                    switch (cmd)
                    {
                        case "Team":
                            teams.Add(new Team(inputArray[1]));
                            break;
                        case "Add":
                            if (teams.Any(t => t.Name == inputArray[1]))
                            {
                                teams.FirstOrDefault(t => t.Name == inputArray[1])
                                    .AddPlayer(new Player(inputArray[2],
                                    new Stats(int.Parse(inputArray[3]), int.Parse(inputArray[4]),
                                    int.Parse(inputArray[5]), int.Parse(inputArray[6]), int.Parse(inputArray[7]))));
                            }
                            else
                            {
                                throw new Exception($"Team {inputArray[1]} does not exist.");
                            }
                            break;
                        case "Remove":
                            if (teams.Any(t => t.Players.Any(p => p.Name == inputArray[2])))
                            {
                                teams.FirstOrDefault(t => t.Name == inputArray[1])
                                    .RemovePlayer(teams.FirstOrDefault(t => t.Name == inputArray[1])
                                    .Players.FirstOrDefault(p => p.Name == inputArray[2]));
                            }
                            else
                            {
                                throw new Exception($"Player {inputArray[2]} is not in {inputArray[1]} team.");
                            }
                            break;
                        case "Rating":
                            if (teams.Any(t => t.Name == inputArray[1]))
                            {
                                Console.WriteLine(teams.FirstOrDefault(t => t.Name == inputArray[1]));
                            }
                            else
                            {
                                throw new Exception($"Team {inputArray[1]} does not exist.");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                input = Console.ReadLine();
            }
        }
    }
}
