using System;
using System.Collections.Generic;

namespace T03.P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, City> cities = new Dictionary<string, City>();
            while (command != "Sail")
            {
                string[] givenCmd = command.Split("||");
                string currCity = givenCmd[0];
                int population = int.Parse(givenCmd[1]);
                int gold = int.Parse(givenCmd[2]);
                if (cities.ContainsKey(currCity))
                {
                    cities[currCity].Gold += gold;
                    cities[currCity].Population += population;
                }
                else
                {
                    City city = new City(population, gold);
                    cities[currCity] = city;
                }
                command = Console.ReadLine();
            }
            string action = Console.ReadLine();
            while (action != "End")
            {
                string[] givenCmd = action.Split("=>");
                string currEvent = givenCmd[0];
                string town = givenCmd[1];
                if (currEvent == "Plunder")
                {
                    int people = int.Parse(givenCmd[2]);
                    int gold = int.Parse(givenCmd[3]);
                    cities[town].Gold -= gold;
                    cities[town].Population -= people;
                    if (cities[town].Gold <= 0 || cities[town].Population <= 0)
                    {
                        if (cities[town].Gold <= 0)
                        {
                            Console.WriteLine($"{town} plundered! {cities[town].Gold + gold} gold stolen, {people} citizens killed.");
                        }
                        else if (cities[town].Population <= 0)
                        {
                            Console.WriteLine($"{town} plundered! {gold} gold stolen, {cities[town].Population + people} citizens killed.");
                        }
                        cities.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                    else
                    {
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    }
                }
                else if (currEvent == "Prosper")
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
                action = Console.ReadLine();
            }
            if (cities.Count == 0)
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var city in cities)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
        }
    }
    class City
    {
        public City(int population, int gold)
        {
            this.Population = population;
            this.Gold = gold;
        }
        public int Population { get; set; }
        public int Gold { get; set; }

    }
}
