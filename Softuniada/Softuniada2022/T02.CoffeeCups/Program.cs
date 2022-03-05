using System;

namespace T02.CoffeeCups
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string text = Console.ReadLine().ToUpper();
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(" ");
                }
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("~");
                    if (i < n - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            PrintTheWidth(n);
            for (int i = 0; i < n - 2; i++)
            {
                if (n / 2 == i+1)
                {
                    Console.Write('|');
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write('~');
                    }
                    Console.Write($"{text}");
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write('~');
                    }
                    Console.Write('|'); 
                    for (int j = 0; j < n - 1; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write('|');
                }
                else
                {
                    Console.Write('|');
                    for (int j = 0; j < n * 2 + text.Length; j++)
                    {
                        Console.Write('~');
                    }
                    Console.Write('|');
                    for (int j = 0; j < n - 1; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write('|');
                }
                Console.WriteLine();
            }
            PrintTheWidth(n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("\\");
                for (int j = 0; j < 6 + ((n-i) * 2) - 2; j++)
                {
                    Console.Write("@");
                }
                Console.WriteLine("/");
            }
            PrintTheFinalLine(n);
        }
        static void PrintTheWidth(int n)
        {
            for (int i = 0; i < 3 * n + 5; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }
        static void PrintTheFinalLine(int n)
        {
            for (int i = 0; i < 3 * n + 5; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}
