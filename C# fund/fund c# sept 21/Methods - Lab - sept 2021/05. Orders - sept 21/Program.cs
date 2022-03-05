using System;

namespace _05._Orders___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            TotalPrice();
        }
        static void TotalPrice()
        {
            string order = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double totalPrice = 0;
            if (order == "coffee")
            {
                totalPrice = quantity * 1.5;
            }
            else if (order == "water")
            {
                totalPrice = quantity * 1;
            }
            else if (order == "coke")
            {
                totalPrice = quantity * 1.4;
            }
            else if (order == "snacks")
            {
                totalPrice = quantity * 2;
            }
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
