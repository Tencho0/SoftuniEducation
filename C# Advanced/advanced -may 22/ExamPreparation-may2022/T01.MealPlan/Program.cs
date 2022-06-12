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

            int atenMeals = 0;

            while (meals.Count > 0 && calories.Count > 0)
            {
                atenMeals++;
                string meal = meals.Dequeue();
                int currCalories = calories.Peek();
                int currMealCalories = ReturnCurrMealCalories(meal);

                if (currCalories - currMealCalories == 0)
                {
                    calories.Pop();
                }
                else if (currCalories - currMealCalories < 0)
                {
                    calories.Pop();
                    if (calories.Count > 0)
                    {
                        calories.Push(calories.Pop() - (currMealCalories - currCalories));
                    }
                }
                else
                {
                    calories.Push(calories.Pop() - currMealCalories);
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
