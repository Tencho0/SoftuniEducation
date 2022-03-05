using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequenceOfElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            int movesUntilNow = 0;
            //   bool isAllHitted = false;
            while (/*command != "end"*/true)
            {
                //if (sequenceOfElements.Count == 0)
                //{
                ////    isAllHitted = true;
                //    break;
                //}
                if (command == "end")
                {
                    break;
                }
                movesUntilNow++;
                int[] givenCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int firstIndex = givenCommand[0];
                int secondIndex = givenCommand[1];
                if (IsValidIndex(firstIndex, secondIndex, sequenceOfElements))
                {
                    if (sequenceOfElements[firstIndex] == sequenceOfElements[secondIndex])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {sequenceOfElements[firstIndex]}!");
                        if (firstIndex > secondIndex)
                        {
                            sequenceOfElements.RemoveAt(firstIndex);
                            sequenceOfElements.RemoveAt(secondIndex);
                        }
                        else
                        {
                            sequenceOfElements.RemoveAt(secondIndex);
                            sequenceOfElements.RemoveAt(firstIndex);
                        }

                        if (sequenceOfElements.Count == 0)
                        {
                            Console.WriteLine($"You have won in {movesUntilNow} turns!");
                            return;
                        }
                        //if (firstIndex == 0 || secondIndex == 0)
                        //{
                        //    sequenceOfElements.RemoveAt(0);
                        //    if (firstIndex == 0)
                        //    {
                        //        sequenceOfElements.RemoveAt(secondIndex - 1);
                        //    }
                        //    else
                        //    {
                        //        sequenceOfElements.RemoveAt(firstIndex - 1);
                        //    }
                        //}
                    }
                    else if (sequenceOfElements[firstIndex] != sequenceOfElements[secondIndex])
                    {
                        Console.WriteLine("Try again!");
                    }
                }
                else
                {
                    // int middleIndex = sequenceOfElements.Count / 2;
                    sequenceOfElements.Insert(sequenceOfElements.Count / 2, $"-{movesUntilNow}a");
                    sequenceOfElements.Insert(sequenceOfElements.Count / 2, $"-{movesUntilNow}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                command = Console.ReadLine();
                //movesUntilNow++;
            }
            //if (isAllHitted)
            //{
            //    Console.WriteLine($"You have won in {movesUntilNow - 1} turns!");
            //}
            //else
            //  {
            Console.WriteLine($"Sorry you lose :(");
            Console.WriteLine(string.Join(" ", sequenceOfElements));
            //  }
        }
        static bool IsValidIndex(int firstIndex, int secondIndex, List<string> sequenceOfElements)
        {
            return firstIndex >= 0 && secondIndex >= 0 && firstIndex < sequenceOfElements.Count && secondIndex < sequenceOfElements.Count && firstIndex != secondIndex;
        }
    }
}
