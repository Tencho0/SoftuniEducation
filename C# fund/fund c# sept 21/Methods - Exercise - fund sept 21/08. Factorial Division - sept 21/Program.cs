using System;

namespace _08._Factorial_Division___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            long firstDigit = int.Parse(Console.ReadLine());
            long secondDigit = int.Parse(Console.ReadLine());
            long firstDigitResult = FirstSum(firstDigit);
            decimal result = SecondSum(secondDigit, firstDigitResult);
            Console.WriteLine($"{result:f2}");
        }
        static long FirstSum(long digit)
        {
            long sum = 1;
            for (long i = digit; i > 0; i--)
            {
                sum *= i;
            }
            return sum;
        }
        static decimal SecondSum (long digit, long firstSum)
        {
            long sum = 1;
            for (long i = digit; i > 0; i--)
            {
                sum *= i;
            }
            decimal finalResult = (decimal)firstSum / sum;
            return finalResult;
        }
    }
}
