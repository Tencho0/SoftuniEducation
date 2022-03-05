using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            PrintNumOfVowels(word);
        }

        private static void PrintNumOfVowels(string word)
        {
            int counter = 0;
            string currWord = word.ToLower();
            for (int i = 0; i < word.Length; i++)
            {
                if (currWord[i] == 'o' || currWord[i] == 'a' || currWord[i] == 'u' || currWord[i] == 'e' || currWord[i] == 'i')
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
