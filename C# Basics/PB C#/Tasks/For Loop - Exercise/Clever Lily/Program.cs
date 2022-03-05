using System;

namespace Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int ageOfLily = int.Parse(Console.ReadLine());
            double priceOfLaundry = double.Parse(Console.ReadLine());
            int priceOfSingeToy = int.Parse(Console.ReadLine());

            int toys = 0;
            int money = 0;
            int totalMoney = 0;
            for (int i = 1; i <= ageOfLily; i++)
            {
                money += 5;

                if (i % 2 == 0)
                {
                    totalMoney += money - 1;
                }
                else
                {
                    toys++;
                }
            }
            totalMoney += toys * priceOfSingeToy;
            if (totalMoney >= priceOfLaundry)
            {
                Console.WriteLine($"Yes! {totalMoney - priceOfLaundry:f2}");
            }
            else
            {
                Console.WriteLine($"No! {priceOfLaundry - totalMoney:f2}");
            }

        }
    }
}
