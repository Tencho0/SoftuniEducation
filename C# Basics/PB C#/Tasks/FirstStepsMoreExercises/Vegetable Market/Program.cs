using System;

namespace Vegetable_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegatablePrice = double.Parse(Console.ReadLine());
            double fruitPrice = double.Parse(Console.ReadLine());
            int vegatableWeight = int.Parse(Console.ReadLine());
            int fruitWeight = int.Parse(Console.ReadLine());

            double vegatableSum = vegatablePrice * vegatableWeight / 1.94;
            double fruitSum = fruitPrice * fruitWeight / 1.94;

            Console.WriteLine($"{vegatableSum + fruitSum:F2}");

        }
    }
}
