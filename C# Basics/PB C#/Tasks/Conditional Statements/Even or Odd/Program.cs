using System;

namespace Even_or_Odd
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            double num1 = num % 2;
            if (num1 == 0) 
            {
                Console.WriteLine("even");
            }

            else
            {
                Console.WriteLine("odd");
            }
        }
    }
}
