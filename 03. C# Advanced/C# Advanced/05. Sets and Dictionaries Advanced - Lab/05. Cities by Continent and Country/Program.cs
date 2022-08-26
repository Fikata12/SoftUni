using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continentsCountriesAndCities = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string continent = input.Split()[0];
                string country = input.Split()[1];
                string city = input.Split()[2];
                if (continentsCountriesAndCities.ContainsKey(continent))
                {
                    if (continentsCountriesAndCities[continent].ContainsKey(country))
                    {
                        continentsCountriesAndCities[continent][country].Add(city);
                    }
                    else
                    {
                        continentsCountriesAndCities[continent].Add(country, new List<string>());
                        continentsCountriesAndCities[continent][country].Add(city);
                    }
                }
                else
                {
                    continentsCountriesAndCities.Add(continent, new Dictionary<string, List<string>>());
                    continentsCountriesAndCities[continent].Add(country, new List<string>());
                    continentsCountriesAndCities[continent][country].Add(city);
                }
            }
            foreach (var continent in continentsCountriesAndCities)
            {
                Console.WriteLine($"{continent.Key}: ");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {String.Join(", ", country.Value)}");
                }
            }
        }
    }
}
