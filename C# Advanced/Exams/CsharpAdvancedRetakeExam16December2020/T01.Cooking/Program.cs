using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Cooking
{
    internal class Program
    {
        static Dictionary<int, string> foods = new Dictionary<int, string>()
        {
            {25, "Bread" },
            {50 ,"Cake" },
            {75 ,"Pastry" },
            {100,"Fruit Pie" }
        };
        static Dictionary<string, int> coockedFoods = new Dictionary<string, int>()
        {
            {"Bread" ,0},
            {"Cake" ,0},
            {"Fruit Pie",0 },
            {"Pastry" ,0}
        };
        static void Main(string[] args)
        {
            int[] givenLiquids = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] givenIngredients = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> liquids = new Queue<int>(givenLiquids);
            Stack<int> ingredients = new Stack<int>(givenIngredients);

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currLiquids = liquids.Dequeue();
                int currIngredients = ingredients.Peek();
                int sum = currLiquids + currIngredients;
                if (foods.ContainsKey(sum))
                {
                    ingredients.Pop();
                    string currFood = foods[sum];
                    coockedFoods[currFood]++;
                }
                else
                {
                    ingredients.Push(ingredients.Pop() + 3);
                }
            }
            PrintResult(liquids, ingredients);
        }

        private static void PrintResult(Queue<int> liquids, Stack<int> ingredients)
        {
            if (!coockedFoods.Any(x => x.Value == 0))
                Console.WriteLine($"Wohoo! You succeeded in cooking all the food!");
            else
                Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to cook everything.");

            if (liquids.Count == 0)
                Console.WriteLine($"Liquids left: none");
            else
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");

            if (ingredients.Count == 0)
                Console.WriteLine($"Ingredients left: none");
            else
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");

            PrintFoods();
        }

        private static void PrintFoods()
        {
            foreach (var (food, amount) in coockedFoods)
                Console.WriteLine($"{food}: {amount}");
        }
    }
}
