using System;

namespace _03._Characters_in_Range___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            PrintCharacters(a, b);
        }
        static void PrintCharacters(char a, char b)
        {
            int first = Math.Min(a,b);
            int second = Math.Max(a, b);
            for (int i = first + 1; i < second ; i++)
            {
                Console.Write((char)i + " ");
            }
            Console.WriteLine();
        }
    }
}
