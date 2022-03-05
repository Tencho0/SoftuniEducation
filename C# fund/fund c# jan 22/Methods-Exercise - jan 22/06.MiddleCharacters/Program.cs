using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            PrintTheMiddleCharacter(word);
        }

        private static void PrintTheMiddleCharacter(string word)
        {
            if (word.Length % 2 == 0)
            {
                Console.Write(word[word.Length / 2 - 1]);
                Console.Write(word[word.Length / 2]);
            }
            else
            {
                Console.Write(word[word.Length / 2]);
            }
        }
    }
}
