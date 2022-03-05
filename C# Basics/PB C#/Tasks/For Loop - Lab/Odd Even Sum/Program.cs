using System;

namespace Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());

            double evenSum = 0;
            double oddSum = 0;

            for (int i = 0; i < times; i++)
            {
                int n = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += n;
                }
                else
                {
                    oddSum += n;
                }
            }
            if (evenSum == oddSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evenSum}");
            }
            else
            {
                double difference = Math.Abs(evenSum - oddSum);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {difference}");
            }
        }
    }
}
