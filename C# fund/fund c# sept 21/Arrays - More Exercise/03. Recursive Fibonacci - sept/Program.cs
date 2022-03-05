using System;

namespace _03._Recursive_Fibonacci___sept
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSequence = int.Parse(Console.ReadLine());
            int[] fibonacciArray = new int[51];
            fibonacciArray[0] = 1;
            fibonacciArray[1] = 1;
            for (int i = 2; i < fibonacciArray.Length; i++)
            {
                fibonacciArray[i] = fibonacciArray[i-1] + fibonacciArray[i - 2];
            }
            Console.WriteLine(fibonacciArray[numberOfSequence - 1]);
        }
    }
}
