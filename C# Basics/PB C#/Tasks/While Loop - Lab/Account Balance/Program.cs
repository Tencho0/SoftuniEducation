using System;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;
            while (input != "NoMoreMoney")
            {
                double currentNum = double.Parse(input);
                if (currentNum < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                else
                {
                    sum += currentNum;
                }
                Console.WriteLine($"Increase: {currentNum:F2}");
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {sum:F2}");
        }
    }
}
