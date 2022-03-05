using System;
using System.Numerics;

namespace _03._Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumber = int.Parse(Console.ReadLine());
            decimal sumOfAll = 0;
            for (int i = 1; i <= numberOfNumber; i++)
            {
                sumOfAll += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(sumOfAll);
        }
    }
}
