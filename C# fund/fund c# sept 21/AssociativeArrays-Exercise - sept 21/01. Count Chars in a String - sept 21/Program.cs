using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            //char[] word = Console.ReadLine().ToCharArray();
            //Dictionary<char, int> counter = new Dictionary<char, int>();
            //foreach (var letter in word)
            //{
            //    if (letter != ' ')
            //    {
            //        if (!(counter.ContainsKey(letter)))
            //        {
            //            counter[letter] = 0;
            //        }
            //        counter[letter]++;
            //    }
            //}
            //foreach (var letter in counter)
            //{
            //    Console.WriteLine($"{letter.Key} -> {letter.Value}");
            //}

            string[] sequence = Console.ReadLine().Split();
            Dictionary<char, int> count = new Dictionary<char, int>();
            foreach (var words in sequence)
            {
                int index = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    char letter = words[index];
                    index++;
                    if (count.ContainsKey(letter))
                        count[letter]++;
                    else
                        count.Add(letter, 1);
                }
            }
            foreach (var item in count)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
