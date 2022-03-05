using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split().ToArray();
            Dictionary<string, int> words = new Dictionary<string, int>();
            foreach (var word in arr)
            {
                string currWord = word.ToLower();
                if (!words.ContainsKey(currWord))
                {
                    words[currWord] = 0;
                }
                words[currWord]++;
            }
            foreach (var currWord in words)
            {
                if (currWord.Value % 2 != 0)
                {
                    Console.Write($"{currWord.Key} ");
                }
            }
        }
    }
}
