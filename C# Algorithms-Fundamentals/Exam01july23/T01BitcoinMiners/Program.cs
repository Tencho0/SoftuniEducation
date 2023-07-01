namespace T01BitcoinMiners
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());

            int result = CalculateCombinations(n, x);
            Console.WriteLine(result);
        }

        private static int CalculateCombinations(int n, int x)
        {
            if (x == 0 || x == n)
            {
                return 1;
            }

            return CalculateCombinations(n - 1, x - 1) + CalculateCombinations(n - 1, x);
        }
    }
}
