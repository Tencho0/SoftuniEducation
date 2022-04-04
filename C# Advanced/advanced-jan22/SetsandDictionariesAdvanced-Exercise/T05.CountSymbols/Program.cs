using System;
using System.Collections.Generic;

namespace T05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
            string input = Console.ReadLine();
            foreach (var letter in input)
            {
                if (!chars.ContainsKey(letter))
                {
                    chars[letter] = 0;
                }
                chars[letter]++;
            }
            foreach (var currChar in chars)
            {
                Console.WriteLine($"{currChar.Key}: {currChar.Value} time/s");
            }
        }
    }
}
