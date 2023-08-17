namespace T03LongestStringChain
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split()
                .ToArray();

            var bestLen = new int[words.Length];
            var parent = new int[words.Length];
            var maxLen = 0;
            var lastIdx = 0;

            for (int current = 0; current < words.Length; current++)
            {
                var currentString = words[current];
                var currentBestLen = 1;
                var currentParent = -1;

                for (int prev = current - 1; prev >= 0; prev--)
                {
                    var prevString = words[prev];
                    var prevLen = bestLen[prev];

                    if (currentString.Length > prevString.Length &&
                        prevLen + 1 >= currentBestLen)
                    {
                        currentBestLen = prevLen + 1;
                        currentParent = prev;
                    }
                }

                bestLen[current] = currentBestLen;
                parent[current] = currentParent;

                if (currentBestLen > maxLen)
                {
                    maxLen = currentBestLen;
                    lastIdx = current;
                }
            }

            var chain = new Stack<string>();

            while (lastIdx != -1)
            {
                var str = words[lastIdx];
                chain.Push(str);
                lastIdx = parent[lastIdx];
            }

            Console.WriteLine(string.Join(" ", chain));
        }
    }
}