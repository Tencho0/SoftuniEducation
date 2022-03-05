using System;
using System.Collections.Generic;

namespace T01.CountCharsinaString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
          //  string givenWord = Console.ReadLine();
            Dictionary<char, int> lettersOccurrences = new Dictionary<char, int>();
            foreach (var word in input)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (!lettersOccurrences.ContainsKey(word[i]))
                    {
                        lettersOccurrences[word[i]] = 0;
                    }
                    lettersOccurrences[word[i]]++;
                }
            }
            //for (int i = 0; i < givenWord.Length; i++)
            //{
            //    if (givenWord[i] == ' ')
            //    {
            //        continue;
            //    }
            //    if (!lettersOccurrences.ContainsKey(givenWord[i]))
            //    {
            //        lettersOccurrences[givenWord[i]] = 0;
            //    }
            //    lettersOccurrences[givenWord[i]]++;
            //}
            foreach (var currLetter in lettersOccurrences)
            {
                Console.WriteLine($"{currLetter.Key} -> {currLetter.Value}");
            }
        }
    }
}
