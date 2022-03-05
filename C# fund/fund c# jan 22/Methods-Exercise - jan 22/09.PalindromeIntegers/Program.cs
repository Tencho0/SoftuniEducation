using System;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            while (word != "END")
            {
                string result = GiveBackForLoop(word.Length, word).ToString().ToLower();
                Console.WriteLine(result);
                word = Console.ReadLine();
            }
        }
        public static bool GiveBackForLoop(int number, string givenWord)
        {
            for (int i = 0; i < number; i++)
            {
                if (givenWord[i] != givenWord[givenWord.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
