using System;

namespace _4._1__Food_for_Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());
            int foodDog = 0;
            int foodCat = 0;
            int totalfoodDog = 0;
            int totalfoodCat = 0;
            double bisquid = 0;

            for (int i = 1; i <= days; i++)
            {
                foodDog = int.Parse(Console.ReadLine());
                foodCat = int.Parse(Console.ReadLine());
                totalfoodDog += foodDog;
                totalfoodCat += foodCat;
                if (i % 3 == 0)
                {
                    bisquid += (foodDog + foodCat) * 0.1;
                }
            }
            bisquid = Math.Round(bisquid);
            double totalFood = totalfoodDog + totalfoodCat;
            double totalEatenFood = totalFood / food * 100;
            double percentDog = totalfoodDog / totalFood * 100;
            double percentCat = totalfoodCat / totalFood * 100;
            Console.WriteLine($"Total eaten biscuits: {bisquid}gr.");
            Console.WriteLine($"{totalEatenFood:F2}% of the food has been eaten.");
            Console.WriteLine($"{percentDog:F2}% eaten from the dog.");
            Console.WriteLine($"{percentCat:F2}% eaten from the cat.");
        }
    }
}
