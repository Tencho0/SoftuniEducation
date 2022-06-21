using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.FoodFinder
{
    internal class Program
    {
        //static Dictionary<string, int> foods = new Dictionary<string, int>()
        //{
        //    {"pear", 0},
        //    {"flour", 0},
        //    {"pork", 0},
        //    {"olive", 0},
        //};
        static void Main(string[] args)
        {
            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";

            List<char> listpear = new List<char>();
            List<char> listflour = new List<char>();
            List<char> listpork = new List<char>();
            List<char> listolive = new List<char>();

            List<string> words = new List<string>();

            char[] givenVowels = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            char[] givenConsonants = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(char.Parse)
               .ToArray();

            Queue<char> vowels = new Queue<char>(givenVowels);
            Stack<char> consonants = new Stack<char>(givenConsonants);

            while (vowels.Count > 0 && consonants.Count > 0)
            {
                char currVowel = vowels.Peek();
                char currConsonant = consonants.Pop();

                if (CheckElement(currVowel, currConsonant, listpear, pear))
                {
                    if (!words.Contains(pear))
                        words.Add(pear);
                }
                if (CheckElement(currVowel, currConsonant, listflour, flour))
                {
                    if (!words.Contains(flour))
                        words.Add(flour);
                }
                if (CheckElement(currVowel, currConsonant, listpork, pork))
                {
                    if (!words.Contains(pork))
                        words.Add(pork);
                }
                if (CheckElement(currVowel, currConsonant, listolive, olive))
                {
                    if (!words.Contains(olive))
                        words.Add(olive);
                }

                vowels.Enqueue(vowels.Dequeue());
            }

            PrintResult(words);
        }

        private static void PrintResult(List<string> words)
        {
            Console.WriteLine($"Words found: {words.Count}");

            if (words.Contains("pear"))
                Console.WriteLine("pear");
            if (words.Contains("flour"))
                Console.WriteLine("flour");
            if (words.Contains("pork"))
                Console.WriteLine("pork");
            if (words.Contains("olive"))
                Console.WriteLine("olive");

            //   foreach (var word in words)
            //   {
            //       Console.WriteLine(word);
            //   }
        }
        private static bool CheckElement(char currVowel, char currConsonant, List<char> list, string word)
        {
            if (word.Contains(currVowel))
            {
                if (!list.Contains(currVowel))
                {
                    list.Add(currVowel);
                }
            }
            if (word.Contains(currConsonant))
            {
                if (!list.Contains(currConsonant))
                {
                    list.Add(currConsonant);
                }
            }

            if (word.Length == list.Count)
            {
                foreach (var letter in list)
                {
                    if (!word.Contains(letter))
                        return false;
                }
                return true;
            }
            return false;
        }
    }
}
