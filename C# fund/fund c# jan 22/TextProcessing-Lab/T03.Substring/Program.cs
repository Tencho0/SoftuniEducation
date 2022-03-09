using System;

namespace T03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            while (text.Contains(word))
            {
                text = text.Remove(text.IndexOf(word),word.Length);
            }
            Console.WriteLine(text);
        }
    }
}
