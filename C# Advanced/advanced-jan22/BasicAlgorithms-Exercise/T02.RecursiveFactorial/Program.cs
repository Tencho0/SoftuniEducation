using System;

namespace T02.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());  
            Console.WriteLine(GetSum(n));
        }

        private static long GetSum(long n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * GetSum(n - 1);
        }
    }
}
