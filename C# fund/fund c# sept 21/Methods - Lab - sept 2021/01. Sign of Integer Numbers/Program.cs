using System;

namespace _01._Sign_of_Integer_Numbers
{
    class Program
    {
        static void SignOfInteger(int a)
        {
            if (a > 0)
            {
                Console.WriteLine($"The number {a} is positive.");
            }
            else if (a < 0)
            {
                Console.WriteLine($"The number {a} is negative.");
            }
            else
            {
                Console.WriteLine($"The number 0 is zero.");
            }
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            SignOfInteger(a);
        }
    }
}
