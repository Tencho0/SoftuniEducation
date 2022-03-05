using System;

namespace _3._1___Energy_Booster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int sets = int.Parse(Console.ReadLine());

            double price = 0;
            if (fruit == "Watermelon")
            {
                if (size == "small")
                {
                    price = 2 * 56 * sets;
                }
                else
                {
                    price = 5 * 28.7 * sets;
                }
            }
            else if (fruit == "Mango")
            {
                if (size == "small")
                {
                    price = 2 * 36.66 * sets;
                }
                else
                {
                    price = 5 * 19.60 * sets;
                }
            }
            else if (fruit == "Pineapple")
            {
                if (size == "small")
                {
                    price = 2 * 42.10 * sets;
                }
                else
                {
                    price = 5 * 24.80 * sets;
                }
            }
            else if (fruit == "Raspberry")
            {
                if (size == "small")
                {
                    price = 2 * 20 * sets;
                }
                else
                {
                    price = 5 * 15.20 * sets;
                }
            }
            if (price > 1000)
            {
                price *= 0.5;
            }
            else if (price >= 400)
            {
                price *= 0.85;
            }
            Console.WriteLine($"{price:F2} lv.");
        }
    }
}
