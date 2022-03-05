using System;

namespace _06._Middle_Characters___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Result(input);
        }
        static void Result(string input)
        {
            if (input.Length % 2 != 0)
            {
                Console.WriteLine(input[input.Length / 2]);
            }
            else
            {
                Console.Write(input[input.Length / 2 - 1]);
                Console.WriteLine(input[input.Length / 2]);
            }
        }
    }
}
