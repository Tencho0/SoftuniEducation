using System;
using System.Linq;

namespace T03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> func = x => char.IsUpper(x[0]);
            Console.WriteLine(string.Join("\n", words.Where(func)));

            //Func<string, bool> func = IsFirstLetterCapital;
            //foreach (var word in words)
            //{
            //    if (func(word))
            //    {
            //        Console.WriteLine(word);
            //    }
            //}
        }

        //static bool IsFirstLetterCapital(string word)
        //{
        //    return char.IsUpper(word[0]);
        //}
    }
}
