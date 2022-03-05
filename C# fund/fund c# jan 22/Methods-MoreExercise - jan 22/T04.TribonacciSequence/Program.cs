using System;

namespace T04.TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintTribonacciSequence(number);
        }
        static void PrintTribonacciSequence(int number)
        {

            int[] currFibonacciNums = new int[number];
            PrintTheCheckResult(number, currFibonacciNums);
        }
        static bool ReturnIsBiggerThan3(int number)
        {
            if (number < 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static void PrintTheCheckResult(int number, int[] currFibonacciNums)
        {
            if (ReturnIsBiggerThan3(number))
            {
                currFibonacciNums[0] = 1;
                currFibonacciNums[1] = 1;
                currFibonacciNums[2] = 2;
                for (int i = 3; i < number; i++)
                {
                    currFibonacciNums[i] = currFibonacciNums[i - 1] + currFibonacciNums[i - 2] + currFibonacciNums[i - 3];
                }
                Console.WriteLine(string.Join(" ", currFibonacciNums));
            }
            else
            {
                for (int i = 0; i < number; i++)
                {
                    Console.Write(1 + " ");
                }
            }
        }
    }
}
