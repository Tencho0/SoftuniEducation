using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenCmd = Console.ReadLine().Split("<->");
                string plantName = givenCmd[0];
                int rarity = int.Parse(givenCmd[1]);
                Plant plant = new Plant()
                {
                    Rarity = rarity
                };
                plants[plantName] = plant;
            }
            string command = Console.ReadLine();
            while (command != "Exhibition")
            {
                string[] givenCmd = command
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                string[] plantData = givenCmd[1]
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string plant = plantData[0];
                if (plants.ContainsKey(plant))
                {
                    if (action == "Rate")
                    {
                        int rating = int.Parse(plantData[1]);
                        plants[plant].Rating.Add(rating);
                    }
                    else if (action == "Update")
                    {
                        int rarity = int.Parse(plantData[1]);
                        plants[plant].Rarity = rarity;
                    }
                    else if (action == "Reset")
                    {
                        plants[plant].Rating.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Plants for the exhibition:");
            foreach (var plant in plants)
            {
                double averageRating = 0;
                if (plant.Value.Rating.Count != 0)
                {
                    averageRating = plant.Value.Rating.Average();
                }
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {averageRating:F2}");
            }
        }
    }
    class Plant
    {
        public Plant()
        {
            Rating = new List<int>();
        }
        public int Rarity { get; set; }
        public List<int> Rating { get; set; }
    }
}
