using System;

namespace _5._1___Care_of_Puppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int gramsFoodPerMeal = 0;
            int food = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "Adopted")
            {
                gramsFoodPerMeal += int.Parse(input);
                input = Console.ReadLine();
            }
            food *= 1000;
            int difference = Math.Abs(gramsFoodPerMeal - food);
            if (gramsFoodPerMeal <= food)
            {
                Console.WriteLine($"Food is enough! Leftovers: {difference} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {difference} grams more.");
            }
        }
    }
}
