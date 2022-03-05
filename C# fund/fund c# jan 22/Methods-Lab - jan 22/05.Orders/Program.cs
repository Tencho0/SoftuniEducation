using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            PrintPorductPrice(product, quantity);
        }

        private static void PrintPorductPrice(string product, int quantity)
        {
            double coffeePricePerOne = 1.5;
            double waterPricePerOne = 1;
            double cokePricePerOne = 1.4;
            double snacksPricePerOne = 2;

            double totalPriceForAllProducts = 0;

            switch (product)
            {
                case "coffee": totalPriceForAllProducts = coffeePricePerOne * quantity; break;
                case "water": totalPriceForAllProducts = waterPricePerOne * quantity; break;
                case "coke": totalPriceForAllProducts = cokePricePerOne * quantity; break;
                case "snacks": totalPriceForAllProducts = snacksPricePerOne * quantity; break;
            }
            Console.WriteLine($"{totalPriceForAllProducts:f2}");
        }
    }
}
