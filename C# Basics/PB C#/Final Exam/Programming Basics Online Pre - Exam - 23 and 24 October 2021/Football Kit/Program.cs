using System;

namespace Football_Kit
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceForTshirt = double.Parse(Console.ReadLine());
            double neededPriceForBall = double.Parse(Console.ReadLine());

            double priceForShorts = priceForTshirt * 0.75;
            double priceForSoccers = priceForShorts * 0.2;

            double priceForTshirtAndShorts = priceForShorts + priceForTshirt;
            double priceForShoe = priceForTshirtAndShorts * 2;

            double totalMoneyWithoutDiscount = priceForShorts + priceForShoe + priceForSoccers + priceForTshirt;
            double totalMoney = totalMoneyWithoutDiscount * 0.85;

            if (totalMoney >= neededPriceForBall)
            {
                Console.WriteLine($"Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {totalMoney:F2} lv.");
            }
            else
            {
                double difference = neededPriceForBall - totalMoney;
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {difference:F2} lv. more.");
            }
        }
    }
}
