using System;

namespace _01.SmallestofThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            PrintSmallestNum(firstNum, secondNum, thirdNum);
        }

        private static void PrintSmallestNum(int firstNum, int secondNum, int thirdNum)
        {
            if (firstNum <= secondNum)
            {
                if (secondNum <= thirdNum)
                {
                    Console.WriteLine(firstNum);
                }
                else
                {
                    if (firstNum <= thirdNum)
                    {
                        Console.WriteLine(firstNum);
                    }
                    else
                    {
                        Console.WriteLine(thirdNum);
                    }
                }
            }
            else if (secondNum <= firstNum)
            {
                if (firstNum <= thirdNum)
                {
                    Console.WriteLine(secondNum);
                }
                else
                {
                    if (secondNum <= thirdNum)
                    {
                        Console.WriteLine(secondNum);
                    }
                    else
                    {
                        Console.WriteLine(thirdNum);
                    }
                }
            }
        }
    }
}
