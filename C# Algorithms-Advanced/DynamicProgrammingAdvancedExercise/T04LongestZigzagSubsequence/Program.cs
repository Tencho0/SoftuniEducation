namespace T04LongestZigzagSubsequence
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var dp = new int[2, elements.Length];
            var parent = new int[2, elements.Length];

            dp[0, 0] = dp[1, 0] = 1;
            parent[0, 0] = parent[1, 0] = -1;

            var bestLen = 0;
            var lastRow = 0;
            var lastCol = 0;

            for (int current = 1; current < elements.Length; current++)
            {
                var currentNumber = elements[current];

                for (int prev = elements.Length - 1; prev >= 0; prev--)
                {
                    var prevNumber = elements[prev];

                    if (currentNumber > prevNumber &&
                        dp[1, prev] + 1 >= dp[0, current])
                    {
                        dp[0, current] = dp[1, prev] + 1;
                        parent[0, current] = prev;
                    }

                    if (prevNumber > currentNumber
                        && dp[0, prev] + 1 >= dp[1, current])
                    {
                        dp[1, current] = dp[0, prev] + 1;
                        parent[1, current] = prev;
                    }
                }

                if (dp[0, current] > bestLen)
                {
                    bestLen = dp[0, current];
                    lastRow = 0;
                    lastCol = current;
                }

                if (dp[1, current] > bestLen)
                {
                    bestLen = dp[1, current];
                    lastRow = 1;
                    lastCol = current;
                }
            }

            var seq = new Stack<int>();

            while (lastCol != -1)
            {
                seq.Push(elements[lastCol]);
                lastCol = parent[lastRow, lastCol];
                lastRow = lastRow == 1 ? 0 : 1;
            }

            Console.WriteLine(string.Join(" ", seq));
        }
    }
}