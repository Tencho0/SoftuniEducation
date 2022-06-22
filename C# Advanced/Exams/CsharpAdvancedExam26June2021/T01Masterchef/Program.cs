using System;
using System.Collections.Generic;
using System.Linq;

namespace T01Masterchef
{
    internal class Program
    {
        static Dictionary<int, string> dishes = new Dictionary<int, string>()
        {
            {150 , "Dipping sauce"},
            {250 , "Green salad"},
            {300 , "Chocolate cake"},
            {400, "Lobster"}
        };
        static Dictionary<string, int> collectedDishes = new Dictionary<string, int>()
        {
            { "Dipping sauce", 0},
            { "Green salad", 0},
            { "Chocolate cake", 0},
            {"Lobster", 0}
        };
        static void Main(string[] args)
        {
            int[] givenIngredients = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] givenFreshnessLevel = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            Queue<int> ingredients = new Queue<int>(givenIngredients);
            Stack<int> freshnessLevels = new Stack<int>(givenFreshnessLevel);

            while (ingredients.Count > 0 && freshnessLevels.Count > 0)
            {
                int currIngredient = ingredients.Peek();
                int currLevel = freshnessLevels.Peek();

                if (currIngredient == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int totalFreshness = currIngredient * currLevel;

                if (dishes.ContainsKey(totalFreshness))
                {
                    string currDish = dishes[totalFreshness];
                    collectedDishes[currDish]++;
                    ingredients.Dequeue();
                    freshnessLevels.Pop();
                }
                else
                {
                    freshnessLevels.Pop();
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }

            PrintResult(ingredients);
        }

        private static void PrintResult(Queue<int> ingredients)
        {
            //if (collectedDishes.Any(x => x.Value >= 4))
            if (collectedDishes.Values.Sum() >= 4)
                Console.WriteLine($"Applause! The judges are fascinated by your dishes!");
            else
                Console.WriteLine($"You were voted off. Better luck next year.");

            if (ingredients.Count > 0)
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");

            foreach (var (dishName, amount) in collectedDishes.Where(x => x.Value >= 1).OrderBy(x => x.Key))
                Console.WriteLine($" # {dishName} --> {amount}");

        }
    }
}
