using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.MealPlan
{
    internal class Program
    {
        static int SALAD_CALORIES = 350;
        static int SOUP_CALORIES = 490;
        static int PASTA_CALORIES = 680;
        static int STEAK_CALORIES = 790;
        static void Main(string[] args)
        {
            string[] givenMeals = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] givenCalories = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Queue<string> meals = new Queue<string>(givenMeals);
            Stack<int> calories = new Stack<int>(givenCalories);
            int atenMealsCount = 0;
            int difference = 0;
            while (true)
            {
                if (meals.Count == 0 || calories.Count == 0)
                    break;

                string currMeal = meals.Dequeue();
                int currCalories = calories.Peek();
                atenMealsCount++;

                int currMealCalories = ReturnCurrMealCalories(currMeal) + difference;

                if (currCalories - currMealCalories > 0)
                {
                    currCalories -= currMealCalories;
                    calories.Pop();
                    calories.Push(currCalories);
                    difference = 0;
                }
                else if (currCalories - currMealCalories == 0)
                {
                    difference = 0;
                    calories.Pop();
                }
                else if (currCalories - currMealCalories < 0)
                {
                    difference = currMealCalories - currCalories;
                    calories.Pop();

                    if (calories.Count == 0)
                        break;

                    calories.Push(calories.Pop() - difference);
                }
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {atenMealsCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {atenMealsCount} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }

        private static int ReturnCurrMealCalories(string currMeal)
        {
            if (currMeal == "salad")
                return SALAD_CALORIES;

            if (currMeal == "soup")
                return SOUP_CALORIES;

            if (currMeal == "pasta")
                return PASTA_CALORIES;

            if (currMeal == "steak")
                return STEAK_CALORIES;

            throw new ArgumentException("Invalid meal");
        }
    }
}
