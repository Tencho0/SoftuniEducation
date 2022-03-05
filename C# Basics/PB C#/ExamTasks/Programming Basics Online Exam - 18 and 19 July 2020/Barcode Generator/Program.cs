using System;

namespace Barcode_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int fourNum1 = number % 10;
            int fourNum2 = number2 % 10;
            number /= 10;
            number2 /= 10;
            int thirdNum1 = number % 10;
            int thirdNum2 = number2 % 10;
            number /= 10;
            number2 /= 10;
            int secondNum1 = number % 10;
            int secondNum2 = number2 % 10;
            number /= 10;
            number2 /= 10;

            for (int i = number; i <= number2; i++)
            {
                for (int j = secondNum1; j <= secondNum2; j++)
                {
                    for (int k = thirdNum1; k <= thirdNum2; k++)
                    {
                        for (int l = fourNum1; l <= fourNum2; l++)
                        {
                            if (i % 2 != 0 && k % 2 != 0 && j % 2 != 0 && k % 2 != 0 && l % 2 != 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
