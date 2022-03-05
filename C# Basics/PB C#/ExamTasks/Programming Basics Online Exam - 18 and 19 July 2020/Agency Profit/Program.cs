using System;

namespace Agency_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numOldTikets = int.Parse(Console.ReadLine());
            int numKidTikets = int.Parse(Console.ReadLine());
            double priceOld = double.Parse(Console.ReadLine());
            double priceService = double.Parse(Console.ReadLine());

            double priceKid = priceOld * 0.3;
            double totalPriceOld = priceOld + priceService;
            double totalPriceKid = priceKid + priceService;

            double totalSumOfTikets = numOldTikets * totalPriceOld + numKidTikets * totalPriceKid;
            double totalWin = totalSumOfTikets * 0.2;

            Console.WriteLine($"The profit of your agency from {name} tickets is {totalWin:f2} lv.");
        }
    }
}
