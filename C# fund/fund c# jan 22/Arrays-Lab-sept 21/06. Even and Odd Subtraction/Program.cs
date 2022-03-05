using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumEven = 0;
            int sumOdd = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] % 2 == 0)
                {
                    sumEven += sequence[i];
                }
                else
                {
                    sumOdd += sequence[i];
                }
            }
            Console.WriteLine(sumEven - sumOdd);
        }
    }
}
