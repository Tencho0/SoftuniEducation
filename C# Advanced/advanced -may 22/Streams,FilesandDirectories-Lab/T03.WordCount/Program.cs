namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            string wordsFilePath = @"..\..\..\words.txt";
            string textFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"../../../output.txt";
            WordCount.CalculateWordCounts(wordsFilePath, textFilePath, outputFilePath);
        }
    }
    public class WordCount
    {
        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            StreamReader givenWords = new StreamReader(wordsFilePath);
            StreamReader text = new StreamReader(textFilePath);
            using (givenWords)
            {
                using (text)
                {
                    Dictionary<string, int> wordsCount = new Dictionary<string, int>();
                    string[] words = givenWords.ReadToEnd()
                        .ToLower()
                        .Split(new string[] 
                        { " ", ".", $"{Environment.NewLine}", ",", "?", "-"}, StringSplitOptions.RemoveEmptyEntries);
                    string[] textWords = text.ReadToEnd()
                        .ToLower()
                        .Split(new string[] 
                        { " ", ".", $"{Environment.NewLine}", ",", "?","-" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in textWords)
                    {
                        if (words.Contains(word.ToLower()))
                        {
                            foreach (var item in words)
                            {
                                if (!wordsCount.ContainsKey(word))
                                    wordsCount[word] = 0;

                                if (word == item)
                                    wordsCount[word]++;
                            }
                        }
                    }

                    StreamWriter writer = new StreamWriter(outputFilePath);
                    using (writer)
                    {
                        foreach (var word in wordsCount.OrderByDescending(x => x.Value))
                            writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}
