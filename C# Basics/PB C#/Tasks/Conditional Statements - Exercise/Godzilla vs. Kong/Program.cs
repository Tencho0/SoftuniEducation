using System;

namespace Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int extra = int.Parse(Console.ReadLine());
            double priceForWearPerMan = double.Parse(Console.ReadLine());

            double priceForWear = extra * priceForWearPerMan;
            if (extra > 150)
            {
                priceForWear = priceForWear* 0.9;
            }

            double decorPrice = budget * 0.1;
            double totalPrice = priceForWear + decorPrice;

            if (totalPrice > budget)
            {
                double needed = totalPrice - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {needed:F2} leva more.");
            }
            else if ( totalPrice <= budget)
            {
                double needed = budget - totalPrice;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {needed:F2} leva left.");
            }
        }
    }
}
