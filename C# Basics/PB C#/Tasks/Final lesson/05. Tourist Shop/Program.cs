using System;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            int counter = 0;
            double total = 0;

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                double price = double.Parse(Console.ReadLine());
                counter++;

                if (counter % 3 == 0)
                {
                    price = price / 2;
                }

                if (price > budget)
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {price - budget:f2} leva!");
                    break;
                }
                else
                {
                    budget -= price;
                    total += price;
                }

                input = Console.ReadLine();
            }

            if (input == "Stop")
            {
                Console.WriteLine($"You bought {counter} products for {total:f2} leva.");
            }
        }
    }
}
