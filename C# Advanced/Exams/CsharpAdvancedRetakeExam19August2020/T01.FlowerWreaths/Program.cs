using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] givenLilies = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] givenRoses = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int wreaths = 0;
            int sumOfFlowers = 0;

            Queue<int> roses = new Queue<int>(givenRoses);
            Stack<int> lilies = new Stack<int>(givenLilies);

            while (roses.Count > 0 && lilies.Count > 0)
            {
                int currRose = roses.Peek();
                int currLilies = lilies.Peek();
                int sum = currRose + currLilies;

                if (sum == 15)
                {
                    wreaths++;
                    roses.Dequeue();
                    lilies.Pop();
                }
                else if (sum > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                else
                {
                    sumOfFlowers += sum;
                    roses.Dequeue();
                    lilies.Pop();
                }
            }
            wreaths += sumOfFlowers / 15;
            if (wreaths >= 5)
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            else
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
        }
    }
}
