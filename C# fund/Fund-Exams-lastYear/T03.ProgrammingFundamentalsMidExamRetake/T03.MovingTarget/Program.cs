using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCommand = command.Split();
                string currCommand = givenCommand[0];
                int index = int.Parse(givenCommand[1]);
                if (currCommand == "Shoot")
                {
                    int power = int.Parse(givenCommand[2]);
                    if (IsIndexValid(index, sequence))
                    {
                        sequence[index] -= power;
                        if (sequence[index] <= 0)
                        {
                            sequence.RemoveAt(index);
                        }
                    }
                }
                else if (currCommand == "Add")
                {
                    int value = int.Parse(givenCommand[2]);
                    if (IsIndexValid(index, sequence))
                    {
                        sequence.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid placement!");
                    }
                }
                else if (currCommand == "Strike")
                {
                    int radius = int.Parse(givenCommand[2]);
                    if (IsIndexValid(index, sequence))
                    {
                        if (index - radius < 0 || index + radius >= sequence.Count)
                        {
                            Console.WriteLine("Strike missed!");
                            //command = Console.ReadLine();
                            //continue;
                        }
                        else
                        {
                            for (int i = 0; i < 2 * radius + 1; i++)
                            {
                                sequence.RemoveAt(index - radius);
                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join("|", sequence));
        }
        static bool IsIndexValid(int index, List<int> sequence)
        {
            return index >= 0 && index < sequence.Count;
        }
    }
}
