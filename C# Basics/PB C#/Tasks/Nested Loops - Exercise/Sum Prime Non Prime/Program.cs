using System;

namespace Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            int sumOfPrimeNumber = 0;
            int sumOfNonPrimeNumber = 0;

            while (comand != "stop")
            {
                int num = int.Parse(comand);
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    int count = 0;
                    for (int i = 1; i <= num; i++)
                    {
                        if (num % i == 0)
                        {
                            count++;
                        }
                    }
                    if (count == 2)
                    {
                        sumOfPrimeNumber += num;
                    }
                    else
                    {
                        sumOfNonPrimeNumber += num;
                    }
                }

                comand = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumOfPrimeNumber}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumOfNonPrimeNumber}");
        }
    }
}
