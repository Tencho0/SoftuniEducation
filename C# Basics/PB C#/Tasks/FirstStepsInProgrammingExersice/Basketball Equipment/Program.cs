using System;

namespace Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int price = int.Parse(Console.ReadLine());
            double priceShoe = price - price * 0.4;
            double priceOutfit = priceShoe - priceShoe * 0.2;
            double priceBall = priceOutfit * 0.25;
            double priceAccessories = priceBall * 0.20;
            
            Console.WriteLine(price + priceShoe + priceOutfit + priceBall + priceAccessories);
        }
    }
}
