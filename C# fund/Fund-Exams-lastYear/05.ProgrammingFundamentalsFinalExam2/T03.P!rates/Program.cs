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
                string[] givenInput = command.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string town = givenInput[0];
                int population = int.Parse(givenInput[1]);
                int gold = int.Parse(givenInput[2]);

                if (cities.ContainsKey(town))
                {
                    cities[town].Population += population;
                    cities[town].Gold += gold;
                }
                else
                {
                    City city = new City()
                    {
                        Population = population,
                        Gold = gold
                    };
                    cities[town] = city;
                }

                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenInput = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string action = givenInput[0];
                string town = givenInput[1];
                if (action == "Plunder")
                {
                    int population = int.Parse(givenInput[2]);
                    int gold = int.Parse(givenInput[3]);

                    cities[town].Population -= population;
                    cities[town].Gold -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {population} citizens killed.");

                    if (cities[town].Population <= 0 || cities[town].Gold <= 0)
                    {
                        cities.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (action == "Prosper")
                {
                    int gold = int.Parse(givenInput[2]);
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
            if (cities.Count> 0)
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
