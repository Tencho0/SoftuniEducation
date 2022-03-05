using System;

namespace PC_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceForCPU = double.Parse(Console.ReadLine());
            double priceForVideoCard = double.Parse(Console.ReadLine());
            double pricePerRAM = double.Parse(Console.ReadLine());
            int numRAMs = int.Parse(Console.ReadLine());
            double percentDiscount = double.Parse(Console.ReadLine());

            double priceForCPUleva = priceForCPU * 1.57;
            double priceForVideoCardLeva = priceForVideoCard * 1.57;
            double pricePerRAMLeva = pricePerRAM * 1.57;
            double totalPriceForRAMLv = pricePerRAMLeva * numRAMs;

            double priceForCPUafterDiscount = priceForCPUleva - priceForCPUleva * percentDiscount;
            double priceForVideoCardafterDiscount = priceForVideoCardLeva - priceForVideoCardLeva * percentDiscount;

            double totalMoneyLv = priceForVideoCardafterDiscount + priceForCPUafterDiscount + totalPriceForRAMLv;

            Console.WriteLine($"Money needed - {totalMoneyLv:F2} leva.");

        }
    }
}
