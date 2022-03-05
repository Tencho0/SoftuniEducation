using System;

namespace Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            if (city == "Sofia")
            {
                double coffeePrice = 0.5;
                double waterPrice = 0.8;
                double beerPrice = 1.2;
                double sweetsPrice = 1.45;
                double peanutsPrice = 1.60;

                if (product == "coffee")
                {
                    Console.WriteLine(coffeePrice * amount);
                }
                else if (product == "water")
                {
                    Console.WriteLine(waterPrice * amount);
                }
                else if (product == "beer")
                {
                    Console.WriteLine(beerPrice * amount);
                }
                else if (product == "sweets")
                {
                    Console.WriteLine(sweetsPrice * amount);
                }
                else if (product == "peanuts")
                {
                    Console.WriteLine(peanutsPrice * amount);
                }
            }
            else if (city == "Plovdiv")
            {
                double coffeePrice = 0.4;
                double waterPrice = 0.7;
                double beerPrice = 1.15;
                double sweetsPrice = 1.3;
                double peanutsPrice = 1.50;

                if (product == "coffee")
                {
                    Console.WriteLine(coffeePrice * amount);
                }
                else if (product == "water")
                {
                    Console.WriteLine(waterPrice * amount);
                }
                else if (product == "beer")
                {
                    Console.WriteLine(beerPrice * amount);
                }
                else if (product == "sweets")
                {
                    Console.WriteLine(sweetsPrice * amount);
                }
                else if (product == "peanuts")
                {
                    Console.WriteLine(peanutsPrice * amount);
                }
            }
            else if (city == "Varna")
            {
                double coffeePrice = 0.45;
                double waterPrice = 0.7;
                double beerPrice = 1.1;
                double sweetsPrice = 1.35;
                double peanutsPrice = 1.55;

                if (product == "coffee")
                {
                    Console.WriteLine(coffeePrice * amount);
                }
                else if (product == "water")
                {
                    Console.WriteLine(waterPrice * amount);
                }
                else if (product == "beer")
                {
                    Console.WriteLine(beerPrice * amount);
                }
                else if (product == "sweets")
                {
                    Console.WriteLine(sweetsPrice * amount);
                }
                else if (product == "peanuts")
                {
                    Console.WriteLine(peanutsPrice * amount);
                }
            }
        }
    }
}
