using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool isStrongNumber = false;
            if (num < 10)
            {
                isStrongNumber = true;
            }
            else
            {
                int sum = num;
                int currSum = 0;
                while (num > 0)
                {
                    int avSum = 1;
                    int currlastDigit = num % 10;
                    for (int i = 0; i < currlastDigit; i++)
                    {
                        avSum *= currlastDigit - i;
                    }
                    currSum += avSum;
                    num /= 10;
                }
                if (sum == currSum)
                {
                    isStrongNumber = true;
                }
            }
            if (isStrongNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
