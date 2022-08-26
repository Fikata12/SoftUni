using System;
using System.Collections.Generic;
using System.Linq;


namespace _03._Legendary_Farming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();
            bool isObtained = false;

            while (isObtained == false)
            {
                string[] materialsAndQuantities = Console.ReadLine().ToLower().Split().ToArray();
                for (int i = 1; i < materialsAndQuantities.Length; i+=2)
                {
                    if (!materials.ContainsKey(materialsAndQuantities[i]))
                    {
                        materials.Add(materialsAndQuantities[i], int.Parse(materialsAndQuantities[i - 1]));
                    }
                    else
                    {
                        materials[materialsAndQuantities[i]] += int.Parse(materialsAndQuantities[i - 1]);
                    }
                    if (materials.ContainsKey("shards") && materials["shards"] >= 250)
                    {
                        Console.WriteLine($"Shadowmourne obtained!");
                        materials["shards"] -= 250;
                        isObtained = true;
                        break;
                    }
                    else if (materials.ContainsKey("fragments") && materials["fragments"] >= 250)
                    {
                        materials["fragments"] -= 250;
                        Console.WriteLine($"Valanyr obtained!");
                        isObtained = true;
                        break;
                    }
                    else if (materials.ContainsKey("motes") && materials["motes"] >= 250)
                    {
                        materials["motes"] -= 250;
                        Console.WriteLine($"Dragonwrath obtained!");
                        isObtained = true;
                        break;
                    }
                }
            }
            if (materials.ContainsKey("shards"))
            {
                Console.WriteLine($"shards: {materials["shards"]}");
            }
            else
            {
                Console.WriteLine($"shards: 0");
            }           
            if (materials.ContainsKey("motes"))
            {
                Console.WriteLine($"motes: {materials["motes"]}");
            }
            else
            {
                Console.WriteLine($"motes: 0");
            }
            if (materials.ContainsKey("fragments"))
            {
                Console.WriteLine($"fragments: {materials["fragments"]}");
            }
            else
            {
                Console.WriteLine($"fragments: 0");
            }
            foreach (var item in materials)
            {
                if (item.Key != "shards" && item.Key != "fragments" && item.Key != "motes")
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
