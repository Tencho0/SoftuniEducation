namespace T07.RecursiveFibonacci
{
    using System;

    internal class Program
    {
        private static long[] memo;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            memo = new long[n + 1];

            Console.WriteLine(RecursiveFibonacciWithMemoization(n));
        }

        private static long CalcFib(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            return CalcFib(n - 1) + CalcFib(n - 2);
        }

        private static long RecursiveFibonacciWithMemoization(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            memo[n] =
                    RecursiveFibonacciWithMemoization(n - 1) +
                            RecursiveFibonacciWithMemoization(n - 2);
            return memo[n];
        }

    }
}