using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());

            const double premierePrice = 12;
            const double normalPrice = 7.5;
            const double discountlPrice = 5;
            double income = 0;
            if(type == "Premiere")
            {
                income = premierePrice * rows * colums;
            }
            else if (type == "Normal")
            {
                income = normalPrice * rows * colums;
            }
            else if (type == "Discount")
            {
                income = discountlPrice * rows * colums;
            }
            Console.WriteLine($"{income:F2} leva");
        }
    }
}
