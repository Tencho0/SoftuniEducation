using System;

namespace _2.__Cat_Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine());
            int walk = int.Parse(Console.ReadLine());
            int calories = int.Parse(Console.ReadLine());

            double spentCalorie = minutes * 5 * walk;
            double halfEatenCALORIE = calories / 2;

            if (spentCalorie >= halfEatenCALORIE)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {spentCalorie}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {spentCalorie}.");
            }
        }
    }
}
