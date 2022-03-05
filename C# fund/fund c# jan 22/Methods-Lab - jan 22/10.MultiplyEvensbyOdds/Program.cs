using System;

namespace _10.MultiplyEvensbyOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int givenNumber = int.Parse(Console.ReadLine());
            int sumOfAllOdd = GetSumOfOddDigits(givenNumber);
            int sumOfAllEven = GetSumOfEvenDigits(givenNumber);
            int multipleOfEvenAndOdd = GetMultipleOfEvenAndOdds(sumOfAllOdd, sumOfAllEven);
            Console.WriteLine(multipleOfEvenAndOdd);
        }

        private static int GetSumOfOddDigits(int givenNumber)
        {
            int givenNumberLength = Math.Abs(givenNumber).ToString().Length;
            int sumOfOddDigits = 0;
            for (int i = 0; i < givenNumberLength; i++)
            {
                int currDigit = Math.Abs(givenNumber % 10);
                if (currDigit % 2 != 0)
                {
                    sumOfOddDigits += currDigit;
                }
                givenNumber /= 10;
            }
            return sumOfOddDigits;
        }

        private static int GetSumOfEvenDigits(int givenNumber)
        {
            int givenNumberLength = Math.Abs(givenNumber).ToString().Length;
            int sumOfEvenDigits = 0;
            for (int i = 0; i < givenNumberLength; i++)
            {
                int currDigit = Math.Abs(givenNumber % 10);
                if (currDigit % 2 == 0)
                {
                    sumOfEvenDigits += currDigit;
                }
                givenNumber /= 10;
            }
            return sumOfEvenDigits;
        }

        private static int GetMultipleOfEvenAndOdds(int a, int b)
        {
            return a * b;
        }
    }
}
