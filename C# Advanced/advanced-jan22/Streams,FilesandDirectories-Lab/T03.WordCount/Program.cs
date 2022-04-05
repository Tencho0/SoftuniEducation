using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace T03.WordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordsFilePath = @"../../../wordsFile.txt";
            string textFilePath = @"../../../text.txt";
            WordCount.CalculateWordCounts(wordsFilePath, textFilePath);
        }
    }

    public class WordCount
    {
        public static void CalculateWordCounts(string wordsFilePath, string textFilePath)
        {
            StreamReader givenWords = new StreamReader(wordsFilePath);
            StreamReader text = new StreamReader(textFilePath);
            string[] words = givenWords.ReadToEnd().Split(' ');
            string[] textWords = text.ReadToEnd().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount[word] = 0;
                }
                foreach (var textWord in textWords)
                {
                    if (word == textWord)
                    {
                        wordsCount[word]++;
                    }
                }
            }

            StreamWriter writer = new StreamWriter("../../../output.txt");

            foreach (var word in wordsCount.OrderByDescending(x=> x.Value))
            {
                writer.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }

}
