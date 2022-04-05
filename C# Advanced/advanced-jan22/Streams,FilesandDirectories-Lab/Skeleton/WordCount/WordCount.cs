namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using StreamWriter writer = new StreamWriter(outputFilePath);
            using StreamReader reader = new StreamReader(wordsFilePath);
            using StreamReader text = new StreamReader(textFilePath);
            string[] words = reader.ReadToEnd().Split();
            string[] textWords = text.ReadToEnd().Split(new char[] { ' ', ',', '.', '-', '?', '!'}, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                wordsCount[word] = textWords.Count(x => x.ToLower() == word.ToLower());
            }
            wordsCount = wordsCount
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, y => y.Value);
            foreach (var word in wordsCount)
            {
                writer.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
