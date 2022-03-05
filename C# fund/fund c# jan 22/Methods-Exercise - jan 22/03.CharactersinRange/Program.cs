using System;

namespace _03.CharactersinRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            PrintCharactersBetweenGivenTwo(firstChar, secondChar);
        }

        private static void PrintCharactersBetweenGivenTwo(char firstChar, char secondChar)
        {
            int startIndex = firstChar;
            int endIndex = secondChar;

            if (firstChar > secondChar)
            {
                startIndex = secondChar;
                endIndex = firstChar;
            }

            for (int i = startIndex + 1; i < endIndex; i++)
            {
                char currSymbol = (char)i;
                Console.Write(currSymbol + " ");
            }
        }
    }
}
