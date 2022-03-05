using System;

namespace T02DrawaHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                Console.Write(new string('.', n - i));
                Console.Write('*');
                if (i > 1)
                {
                    Console.Write(new string(' ', 2 * i - 3));
                    Console.Write('*');
                }
                Console.WriteLine(new string('.', n - i));
            }
            Console.Write('*');
            for (int i = 1; i < n; i++)
            {
                Console.Write(" *");
            }
            Console.WriteLine();
            Console.Write('+');
            Console.Write(new string('-', 2 * n - 3));
            Console.Write('+');
            Console.WriteLine();
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write('|');
                Console.Write(new string(' ', 2 * n - 3));
                Console.Write('|');
                Console.WriteLine();
            }
            Console.Write('+');
            Console.Write(new string('-', 2 * n - 3));
            Console.Write('+');
            Console.WriteLine();
        }
    }
}
