using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.MealPlan
{
    internal class Program
    {
        static Dictionary<string, int> mealsCalories = new Dictionary<string, int>()
        {
            { "salad" , 350 },
            { "soup" , 490 },
            { "pasta" , 680 },
            { "steak" , 790 }
        };
        static void Main(string[] args)
        {
            string[] givenMeals = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] givenCalories = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<string> meals = new Queue<string>(givenMeals);
            Stack<int> calories = new Stack<int>(givenCalories);

            int atenMeals = 0;

            while (meals.Count > 0 && calories.Count > 0)
            {
                string currMeal = meals.Dequeue();
                int currCalories = calories.Peek();
                atenMeals++;
                int currMealCalories = mealsCalories[currMeal];

                if (currMealCalories < currCalories)
                {
                    calories.Push(calories.Pop() - currMealCalories);
                }
                else if (currMealCalories == currCalories)
                {
                    calories.Pop();
                }
                else
                {
                    int difference = currMealCalories - calories.Pop();
                    if (calories.Count > 0)
                    {
                        calories.Push(calories.Pop() - difference);
                    }
                }
            }
            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {atenMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {atenMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
