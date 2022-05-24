using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.CitiesbyContinentandCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenCmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = givenCmd[0];
                string country = givenCmd[1];
                string city = givenCmd[2];

                if (!continents.ContainsKey(continent))
                    continents[continent] = new Dictionary<string, List<string>>();
                if (!continents[continent].ContainsKey(country))
                    continents[continent][country] = new List<string>();
                continents[continent][country].Add(city);
            }

            foreach (var (continent, countries) in continents)
            {
                Console.WriteLine($"{continent}:");
                foreach (var (country, towns) in countries)
                    Console.WriteLine($"{country} -> {string.Join(", ", towns)}");
            }
        }
    }
}
