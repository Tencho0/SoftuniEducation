using System;

namespace Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double meters = double.Parse(Console.ReadLine());
            const double CENA = 7.61;
            double priceForGreening = meters * CENA;
            double discount = priceForGreening * 0.18;
            double finalSum = priceForGreening - discount;

            Console.WriteLine($"The final price is: {finalSum} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");

        }
    }
}
