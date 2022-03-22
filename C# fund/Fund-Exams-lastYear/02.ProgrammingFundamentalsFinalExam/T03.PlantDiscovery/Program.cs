using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> plants = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plant = cmd[0];
                int rarity = int.Parse(cmd[1]);
                if (!plants.ContainsKey(plant.Trim()))
                {
                    plants[plant] = new List<double>();
                    plants[plant].Add(rarity);
                }
                else
                {
                plants[plant][0] = rarity;
                }
            }
            string command = Console.ReadLine();
            while (command != "Exhibition")
            {
                string[] givenCmd = command.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string currCommand = givenCmd[0];
                string[] plantGroup = givenCmd[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string plant = plantGroup[0].Trim();
                if (plants.ContainsKey(plant))
                {

                    if (currCommand == "Rate")
                    {
                        plants[plant].Add(double.Parse(plantGroup[1]));
                    }
                    else if (currCommand == "Update")
                    {
                        int newRarity = int.Parse(plantGroup[1]);
                        plants[plant][0] = newRarity;
                    }
                    else if (currCommand == "Reset")
                    {
                        double rarity = plants[plant][0];
                        plants[plant].Clear();
                        plants[plant].Add(rarity);
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
                double rarity = plant.Value[0];
                plant.Value.RemoveAt(0);
                double averageRating = 0;
                if (plant.Value.Count != 0)
                {
                    averageRating = plant.Value.Average();
                }
                Console.WriteLine($"- {plant.Key}; Rarity: {rarity}; Rating: {averageRating:F2}");
            }
        }
    }
}
