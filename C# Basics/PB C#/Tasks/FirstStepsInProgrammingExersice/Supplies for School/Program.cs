using System;

namespace Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            int pensil = int.Parse(Console.ReadLine());
            int marker = int.Parse(Console.ReadLine());
            int preparation = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double pricePensil = pensil * 5.8;
            double priceMarker = marker * 7.2;
            double pricePreparation = preparation * 1.2;

            double priceWithoutDiscount = pricePensil + priceMarker + pricePreparation;
            double priceWithDiscount = priceWithoutDiscount - priceWithoutDiscount * discount / 100;

            Console.WriteLine(priceWithDiscount);

        }
    }
}
