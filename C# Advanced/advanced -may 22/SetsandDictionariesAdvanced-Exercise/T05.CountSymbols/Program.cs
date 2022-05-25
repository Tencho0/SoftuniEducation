using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> letters = new Dictionary<char, int>();
            string word = Console.ReadLine();
            for (int i = 0; i < word.Length; i++)
            {
                char currLetter = word[i];
                if (!letters.ContainsKey(currLetter))
                {
                    letters[currLetter] = 0;
                }
                letters[currLetter]++;
            }


            foreach (var letter in letters.OrderBy(x => x.Key))
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
        }
    }
}
