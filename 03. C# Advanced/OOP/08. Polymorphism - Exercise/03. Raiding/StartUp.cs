using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main()
        {
            List<BaseHero> raidGroup = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                switch (type)
                { case "Druid":
                        raidGroup.Add(new Druid(name));
                        break;
                    case "Paladin":
                        raidGroup.Add(new Paladin(name));
                        break;
                    case "Rogue":
                        raidGroup.Add(new Rogue(name));
                        break;
                    case "Warrior":
                        raidGroup.Add(new Warrior(name));
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        i--;
                        break;
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            int totalPowerTeam = 0;
            foreach (var hero in raidGroup)
            {
                totalPowerTeam += hero.Power;
                Console.WriteLine(hero.CastAbility()); 
            }
            if (totalPowerTeam >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
