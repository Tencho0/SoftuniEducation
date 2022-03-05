using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequenceOfElements = new List<string>();
            string command = Console.ReadLine();
            int movesUntilNow = 0;
            while (command != "end")
	        {
                movesUntilNow++;
                int [] givenCommand= command.Split().Select(int.Parse).ToArray();
                int firstIndex = givenCommand[0];
                int secondIndex = givenCommand[1];
                if (IsValidIndex(firstIndex, secondIndex, sequenceOfElements)
	            {

	            }
                else
            	{
                    int middleIndex = sequenceOfElements.Count / 2;
                    sequenceOfElements.Insert(middleIndex, $"-{movesUntilNow}a")
            	}
                command = Console.ReadLine();
        	}
        }
        static bool IsValidIndex(int firstIndex, int secondIndex, List<string> sequenceOfElements)
        {
            return firstIndex> 0 && secondIndex> 0 && firstIndex < sequenceOfElements.Count - 1 && secondIndex < sequenceOfElements.Count - 1 && firstIndex != secondIndex;
        }
    }
}
