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

            switch(type)
            {
                case "Premiere":
                    income = rows * colums * premierePrice;
                    break;
                case "Normal":
                    income = rows * colums * normalPrice;
                    break;
                case "Discount":
                    income = rows * colums * discountlPrice;
                    break;
            }
            Console.WriteLine($"{income:F2} leva");
        }
    }
}
