using System;

namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fib = int.Parse(Console.ReadLine());
            Console.WriteLine(Fibonacci(fib));
        }

        private static int Fibonacci(int fib)
        {
            if (fib == 0)
                return 0;
         
            if (fib == 1 || fib == 2)
                return 1;

            return Fibonacci(fib - 1) + Fibonacci(fib - 2);
        }
    }
}
