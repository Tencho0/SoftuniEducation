using System;

namespace Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chicken = int.Parse(Console.ReadLine());
            int fish = int.Parse(Console.ReadLine());
            int vegetarian = int.Parse(Console.ReadLine());

            double chickenPrice = chicken * 10.35;
            double fishPrice = fish * 12.40;
            double vegetarianPrice = vegetarian * 8.15;

            double sumWithoutDessert = chickenPrice + fishPrice + vegetarianPrice;
            double sumWithDessert = sumWithoutDessert + sumWithoutDessert * 0.2;
            double totalSum = sumWithDessert + 2.50;

            Console.WriteLine(totalSum);
            
        }
    }
}
