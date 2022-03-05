using System;
using System.Linq;

namespace T04.WordFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] givenWords = Console.ReadLine().Split();
            string[] words = givenWords.Where(x => x.Length % 2 == 0).ToArray();
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}
