namespace T03LongestIncreasingSubsequence
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var lenght = new int[numbers.Length];
            var parent = new int[numbers.Length];

            var bestLenght = 0;
            var bestIdx = 0;

            for (int current = 0; current < numbers.Length; current++)
            {
                var currentNumber = numbers[current];
                var currentLenght = 1;
                var currentParent = -1;

                for (int prev = current - 1; prev >= 0; prev--)
                {
                    var prevNumber = numbers[prev];
                    var prevLenght = lenght[prev];

                    if (currentNumber > prevNumber &&
                        prevLenght + 1 >= currentLenght)
                    {
                        currentLenght = prevLenght + 1;
                        currentParent = prev;
                    }
                }

                lenght[current] = currentLenght;
                parent[current] = currentParent;

                if (currentLenght > bestLenght)
                {
                    bestLenght = currentLenght;
                    bestIdx = current;
                }
            }

            var lis = new Stack<int>();

            while (bestIdx != -1)
            {
                lis.Push(numbers[bestIdx]);
                bestIdx = parent[bestIdx];
            }

            Console.WriteLine(string.Join(" ", lis));
        }
    }
}