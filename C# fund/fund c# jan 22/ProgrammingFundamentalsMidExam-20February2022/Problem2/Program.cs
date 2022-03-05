using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> coffees = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currCommand = givenCmd[0];
                if (currCommand == "Include")
                {
                    string currCoffee = givenCmd[1];
                    coffees.Add(currCoffee);
                }
                else if (currCommand == "Remove")
                {
                    string firstOrLast = givenCmd[1];
                    int numOfCoffees = int.Parse(givenCmd[2]);
                    if (!(coffees.Count < numOfCoffees))
                    {
                        if (firstOrLast == "first")
                        {
                            for (int j = 0; j < numOfCoffees; j++)
                            {
                                coffees.RemoveAt(0);
                            }
                        }
                        else if (firstOrLast == "last")
                        {
                            for (int k = 0; k < numOfCoffees; k++)
                            {
                                coffees.RemoveAt(coffees.Count - 1);
                            }
                        }
                    }
                }
                else if (currCommand == "Prefer")
                {
                    int firstIndex = int.Parse(givenCmd[1]);
                    int secondIndex = int.Parse(givenCmd[2]);
                    if (AreIndicesValid(firstIndex, secondIndex, coffees))
                    {
                        string temp = coffees[firstIndex];
                        coffees[firstIndex] = coffees[secondIndex];
                        coffees[secondIndex] = temp;
                    }
                }
                else if (currCommand == "Reverse")
                {
                    coffees.Reverse();
                }
            }
            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(" ", coffees));
        }
        public static bool AreIndicesValid(int firstIndex, int secondIndex, List<string> coffees)
        {
            return firstIndex >= 0 && firstIndex < coffees.Count && secondIndex >= 0 && secondIndex < coffees.Count;
        }
    }
}
