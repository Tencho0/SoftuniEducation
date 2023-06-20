namespace T06MergeSort
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sorted = MergeSort(elements);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] elements)
        {
            if (elements.Length <= 1)
            {
                return elements;
            }

            var left = elements.Take(elements.Length / 2).ToArray();
            var right = elements.Skip(elements.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var merged = new int[left.Length + right.Length];

            var mergedIndex = 0;
            var leftIndex = 0;
            var rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    merged[mergedIndex++] = left[leftIndex++];
                }
                else
                {
                    merged[mergedIndex++] = right[rightIndex++];
                }
            }
            for (int i = leftIndex; i < left.Length; i++)
            {
                merged[mergedIndex++] = left[i];
            }

            for (int j = rightIndex; j < right.Length; j++)
            {
                merged[mergedIndex++] = right[j];
            }
            return merged;
        }
    }
}