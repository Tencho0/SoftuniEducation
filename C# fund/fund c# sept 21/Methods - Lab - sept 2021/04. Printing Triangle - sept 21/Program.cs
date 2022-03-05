using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintTriangle(number);
        }

        private static void PrintTriangle(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                PrintTriangleLine(i);
                Console.WriteLine();
            }
            for (int i = number -1; i > 0; i--)
            {
                PrintTriangleLine(i);
                Console.WriteLine();
            }
        }

        static void PrintTriangleLine(int line)
        {
            for (int j = 1; j <= line; j++)
            {
                Console.Write(j + " ");
            }
        }
    }
}
