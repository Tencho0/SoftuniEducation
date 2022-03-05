using System;

namespace _03.RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int fibonacciNum = int.Parse(Console.ReadLine());
            long[] currNum = new long[50];
            currNum[0] = 1;
            currNum[1] = 1;
            for (int i = 2; i < 50; i++)
            {
                currNum[i] = currNum[i - 1] + currNum[i - 2];
            }
            Console.WriteLine($"{currNum[fibonacciNum - 1]}");
        }
    }
}
