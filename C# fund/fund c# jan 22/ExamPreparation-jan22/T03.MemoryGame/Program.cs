using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command = Console.ReadLine();
            int reps = 0;
            while (command != "end")
            {
                reps++;
                int[] givenIndexes = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int firstIndex = givenIndexes[0];
                int secondIndex = givenIndexes[1];
                if (firstIndex == secondIndex || firstIndex < 0 || secondIndex < 0 || secondIndex >= sequence.Count || firstIndex >= sequence.Count) 
                {
                    int insertIdnex = sequence.Count / 2;
                    sequence.Insert(insertIdnex, $"-{reps}a");
                    sequence.Insert(insertIdnex, $"-{reps}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else
                {
                    if (sequence[firstIndex] == sequence[secondIndex])
                    {
                        string findedNum = sequence[firstIndex];
                        Console.WriteLine($"Congrats! You have found matching elements - {sequence[firstIndex]}!");
                        sequence.Remove(findedNum);
                        sequence.Remove(findedNum);
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }
                if (sequence.Count == 0)
                {
                    Console.WriteLine($"You have won in {reps} turns!");
                    return;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
