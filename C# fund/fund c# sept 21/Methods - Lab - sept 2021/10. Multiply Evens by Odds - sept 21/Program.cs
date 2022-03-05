using System;

namespace _10._Multiply_Evens_by_Odds___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int evenDigitSum = GetSumOfDigits(number, 0);
            int oddDigitSum = GetSumOfDigits(number, 1);
            Console.WriteLine(evenDigitSum * oddDigitSum);
        }
        static int GetSumOfDigits(int num, int evenOddCheck)
        {
            int sum = 0;
            while (num > 0) 
            {
                int digit = num % 10;
                if (digit % 2 == evenOddCheck)
                {
                    sum += (num % 10);
                }
                num /= 10;
            }
            return sum;
        }
    }
}
