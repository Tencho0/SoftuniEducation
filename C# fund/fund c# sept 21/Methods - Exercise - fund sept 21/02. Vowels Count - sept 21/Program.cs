using System;

namespace _02._Vowels_Count___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine().ToLower();
            Console.WriteLine(VowelsDigits(inputText));
        }
        static int VowelsDigits(string word)
        {
            int count = 0;
            foreach (var vowels in word)
            {
                if ("aeiou".Contains(vowels))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
