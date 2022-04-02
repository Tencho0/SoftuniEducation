using System;
using System.Collections.Generic;

namespace T03.P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> cities = new Dictionary<string, City>();
            string command = Console.ReadLine();
            while (command != "Sail")
            {
                string[] givenCmd = command
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);
                string name = givenCmd[0];
                int population = int.Parse(givenCmd[1]);
                int gold = int.Parse(givenCmd[2]);
                if (cities.ContainsKey(name))
                {
                    cities[name].Population += population;
                    cities[name].Gold += gold;
                }
                else
                {
                    City city = new City()
                    {
                        Population = population,
                        Gold = gold
                    };
                    cities[name] = city;
                }
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCmd = command
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                string town = givenCmd[1];
                if (action == "Plunder")
                {
                    int people = int.Parse(givenCmd[2]);
                    int gold = int.Parse(givenCmd[3]);
                    cities[town].Population -= people;
                    cities[town].Gold -= gold;
                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    if (cities[town].Population <= 0 || cities[town].Gold <= 0 )
                    {
                        cities.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (action == "Prosper")
                {
                    int gold = int.Parse(givenCmd[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[town].Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town].Gold} gold.");
                    }
                }
                command = Console.ReadLine();
            }
            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var city in cities)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
    class City
    {
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
