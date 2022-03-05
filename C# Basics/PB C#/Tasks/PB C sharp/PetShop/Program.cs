using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogFood = int.Parse(Console.ReadLine());
            int catFood = int.Parse(Console.ReadLine());
            const double dogPrice = 2.5;
            const double catPrice = 4;
            double totalPrice = (dogFood * dogPrice) + (catFood * catPrice);
            Console.WriteLine($"{totalPrice} lv.");
        }
    }
}
