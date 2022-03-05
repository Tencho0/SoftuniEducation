using System;

namespace _07._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int price = 0;

            if (day == "Weekday")
            {
                if (0 <= age && age <= 18)
                {
                    price = 12;
                }
                else if (18 < age && age <= 64)
                {
                    price = 18;
                }
                else if (64 < age && age <= 122)
                {
                    price = 12;
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
            else if (day == "Weekend")
            {
                if (0 <= age && age <= 18)
                {
                    price = 15;
                }
                else if (18 < age && age <= 64)
                {
                    price = 20;
                }
                else if (64 < age && age <= 122)
                {
                    price = 15;
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
            else
            {

                if (0 <= age && age <= 18)
                {
                    price = 5;
                }
                else if (18 < age && age <= 64)
                {
                    price = 12;
                }
                else if (64 < age && age <= 122)
                {
                    price = 10;
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
            if (price != 0)
            {
                Console.WriteLine($"{price}$");
            }
        }
    }
}
