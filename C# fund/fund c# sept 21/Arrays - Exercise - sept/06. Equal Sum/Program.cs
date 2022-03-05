using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 0; i <= number.Length - 1; i++)
            {
                if (number.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }

                // LeftSum
                leftSum = 0;
                for (int left = i; left > 0; left--)
                {
                    int nextElementPossition = left - 1;
                    if (left > 0)
                    {
                        leftSum += number[nextElementPossition];
                    }
                }

                // Right sum
                rightSum = 0;
                for (int right = i; right < number.Length; right++)
                {
                    int nextElementPossition = right + 1;
                    if (right < number.Length -1 )
                    {
                        rightSum += number[nextElementPossition];
                    }
                }

                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
