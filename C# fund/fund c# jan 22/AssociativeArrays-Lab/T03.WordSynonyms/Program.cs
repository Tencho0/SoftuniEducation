using System;
using System.Collections.Generic;

namespace T03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string wordKey = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (!synonyms.ContainsKey(wordKey))
                {
                    synonyms[wordKey] = new List<string>();
                }
                synonyms[wordKey].Add(synonym);
            }
            foreach (var currWords in synonyms)
            {
                Console.WriteLine($"{currWords.Key} - {string.Join(", ", currWords.Value)}");
            }
        }
    }
}
