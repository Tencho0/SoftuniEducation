using System;

namespace Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tourPrice = double.Parse(Console.ReadLine());
            int numPuzzle = int.Parse(Console.ReadLine());
            int talkingDolls = int.Parse(Console.ReadLine());
            int teddyBears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double puzzlePrice = numPuzzle * 2.60;
            double talkingDollsPrice = talkingDolls * 3;
            double teddyBearsPrice = teddyBears * 4.10;
            double minionsPrice = minions * 8.2;
            double trucksPrice = trucks * 2;

            int totalNum = numPuzzle + talkingDolls + teddyBears + minions + trucks;

            double totalPrice = puzzlePrice + talkingDollsPrice + teddyBearsPrice + minionsPrice + trucksPrice;

            if (totalNum >= 50)
            {
                totalPrice = totalPrice - totalPrice * 0.25;
            }
            double totalWin = totalPrice - totalPrice * 0.1;
            if (totalWin >= tourPrice)
            {
                double difference = totalWin - tourPrice;
                Console.WriteLine($"Yes! {difference:F2} lv left.");
            }
            else
            {
                double difference = tourPrice - totalWin;
                Console.WriteLine($"Not enough money! {difference:F2} lv needed. ");
            }
          
        }
    }
}
