using System;

namespace Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            const double priceSpring = 3000;
            const double priceSummer = 4200;
            const double priceAutumn = 4200;
            const double priceWinter = 2600;

            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numFishers = int.Parse(Console.ReadLine());

            double discount = 0;
           if(numFishers<=6)
            {
                discount = 0.1;
            }
           else if ( numFishers <= 11)
            {
                discount = 0.15;
            }
           else
            {
                discount = 0.25;
            }
            double price = 0;

                if(season == "Spring")
                    price = priceSpring- priceSpring * discount;

                   else if (season == "Summer")
                    price = priceSummer- priceSummer * discount;

                else if (season == "Autumn")
                price = priceAutumn- priceAutumn * discount;

                else if (season =="Winter")
                    price = priceWinter - priceWinter * discount;
            
            if (season != "Autumn" && numFishers % 2 == 0)
            {
                price -= price * 0.05;
            }
            
            if(budget >= price)
            {
                double moreMoney = budget - price;
                Console.WriteLine($"Yes! You have {moreMoney:F2} leva left.");
            }
            else
            {
                double neededMoney = price - budget;
                Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
            }
        }
    }
}
