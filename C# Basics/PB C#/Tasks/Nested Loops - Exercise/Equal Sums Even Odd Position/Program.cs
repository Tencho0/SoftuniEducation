using System;

namespace Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            for (int num = start; num <= end; num++)
            {
                int currNum = num;
                int evenSum = 0;
                int oddSum = 0;
                int count = 0;
                while (currNum != 0)
                {
                    int digit = currNum % 10;
                    if (count % 2 == 0)
                    {
                        evenSum += digit;
                    }
                    else
                    {
                        oddSum += digit;
                    }
                    currNum /= 10;
                    count++;
                }
                if (evenSum == oddSum)
                {
                    Console.Write($"{num} ");
                }
            }
        }
    }
}
