using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int reps = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < reps; i++)
            {
                char givenChar = char.Parse(Console.ReadLine());
                sum += (int)givenChar;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
