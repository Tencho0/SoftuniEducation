using System;

class Program
{
    private static int maxStart = -1;
    private static int maxEnd = -1;

    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        KadanesAlgorithm(arr);

        int maxSum = 0;
        for (int i = maxStart; i <= maxEnd; i++)
            maxSum += arr[i];

        Console.WriteLine($"{maxSum} {maxStart} {maxEnd}");

        //int maxSum = KadanesAlgorithm(arr);
        //Console.WriteLine($"The maximum subarray sum is {maxSum}");
    }

    static void KadanesAlgorithm(int[] arr)
    {
        int maxSoFar = arr[0];
        int maxEndingHere = arr[0];
        int start = 0;
        int end = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > maxEndingHere + arr[i])
            {
                start = i;
                end = i;
                maxEndingHere = arr[i];
            }
            else
            {
                end = i;
                maxEndingHere = maxEndingHere + arr[i];
            }

            if (maxEndingHere > maxSoFar)
            {
                maxSoFar = maxEndingHere;
                maxStart = start;
                maxEnd = end;
            }
        }
    }

    //static int KadanesAlgorithm(int[] arr)
    //{
    //    int maxSoFar = arr[0];
    //    int maxEndingHere = arr[0];

    //    for (int i = 1; i < arr.Length; i++)
    //    {
    //        maxEndingHere = Math.Max(arr[i], maxEndingHere + arr[i]);
    //        maxSoFar = Math.Max(maxSoFar, maxEndingHere);
    //    }

    //    return maxSoFar;
    //}
}