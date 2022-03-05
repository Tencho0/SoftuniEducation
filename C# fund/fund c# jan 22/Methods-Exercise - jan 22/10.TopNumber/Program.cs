using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int endIndex = int.Parse(Console.ReadLine());
            PrintAllTopIntegers(endIndex);
        }
        private static void PrintAllTopIntegers(int endIndex)
        {
            for (int i = 10; i <= endIndex; i++)
            {
                int currNum = i;
                int sum = 0;
                bool isContainsOddDigit = false;
                while (currNum > 0)
                {
                    int currDigit = currNum % 10;
                    if (!isContainsOddDigit)
                    {
                        if (currDigit % 2 != 0)
                        {
                            isContainsOddDigit = true;
                        }
                    }
                    sum += currDigit;
                    currNum /= 10;
                }
                if (sum % 8 == 0 && isContainsOddDigit)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
