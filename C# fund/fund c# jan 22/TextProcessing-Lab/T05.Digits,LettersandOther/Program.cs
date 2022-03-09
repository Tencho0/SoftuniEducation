using System;
using System.Text;

namespace T05.Digits_LettersandOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder characters = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];
                if (Char.IsDigit(currChar))
                {
                    digits.Append(currChar);
                }
                else if (char.IsLetter(currChar))
                {
                    letters.Append(currChar);
                }
                else
                {
                    characters.Append(currChar);
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(characters);
        }
    }
}
