using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededVacationMoney = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());
            int days = 0;
            int spentCounter = 0;
            while (spentCounter != 5)
            {
                string input = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                days++;
                if (input == "save")
                {
                    currentMoney += money;
                    spentCounter = 0;
                }
                else if (input == "spend")
                {
                    spentCounter++;
                    if (money > currentMoney)
                    {
                        currentMoney = 0;
                    }
                    else
                    {
                        currentMoney -= money;
                    }
                }
                if (currentMoney >= neededVacationMoney)
                {
                    Console.WriteLine($"You saved the money for {days} days.");
                    break;
                }
            }
            if (spentCounter == 5)
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine($"{days}");
            }
        }
    }
}
