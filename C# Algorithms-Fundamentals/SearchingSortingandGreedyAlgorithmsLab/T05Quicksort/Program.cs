namespace T05Quicksort
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            QuickSort(numbers, 0, numbers.Length - 1);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void QuickSort(int[] numbers, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = numbers[end];
            var left = start;
            var right = end - 1;

            while (left <= right)
            {
                if (numbers[left] < pivot)
                {
                    left++;
                }
                else if (numbers[right] >= pivot)
                {
                    right--;
                }
                else
                {
                    Swap(numbers, left, right);
                }
            }

            Swap(numbers, left, end);

            QuickSort(numbers, start, left - 1);
            QuickSort(numbers, left + 1, end);
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}