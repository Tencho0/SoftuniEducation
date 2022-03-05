using System;
using System.Collections.Generic;

namespace T01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Random random = new Random();
            for (int i = 0; i < words.Length; i++)
            {
                int swapPossition = random.Next(words.Length);
                string temp = words[i];
                words[i] = words[swapPossition];
                words[swapPossition] = temp;
            }
            Console.WriteLine(string.Join("\n", words));
        }
    }
}
