using System;
using System.Linq;

namespace T01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(GetSum(n, 0));
        }

        private static int GetSum(int[] arr, int index)
        {
            int sum = 0;
            if (index == arr.Length - 1)
            {
                return arr[index];
            }
            sum += arr[index] + GetSum(arr, index + 1);
            return sum;
        }
    }
}
