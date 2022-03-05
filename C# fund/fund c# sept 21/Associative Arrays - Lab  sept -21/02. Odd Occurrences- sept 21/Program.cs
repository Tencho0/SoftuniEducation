using System;
using System.Collections.Generic;

namespace _02._Odd_Occurrences__sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sequenceOfWords = Console.ReadLine().Split();
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (var word in sequenceOfWords)
            {
                string wordInLowerCase = word.ToLower();
                if (counts.ContainsKey(wordInLowerCase))
                    counts[wordInLowerCase]++;
                else
                    counts.Add(wordInLowerCase, 1);
            }

            foreach (var word in counts)
            {
                if (!(word.Value % 2 == 0)) 
                    Console.Write(word.Key + " ");
            }
        }
    }
}
