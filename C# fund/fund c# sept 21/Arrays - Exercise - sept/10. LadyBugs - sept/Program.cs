using System;
using System.Linq;

namespace _10._LadyBugs___sept
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladyBugField = new int[fieldSize];
            string[] ocupiedIndexes = Console.ReadLine().Split();

            for (int i = 0; i < ocupiedIndexes.Length; i++)
            {
                int currentIndex = int.Parse(ocupiedIndexes[i]);
                if (currentIndex >= 0 && currentIndex < fieldSize)
                {
                    ladyBugField[currentIndex] = 1;
                }
            }
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                int currentIndex = int.Parse(command[0]);
                bool isFirst = true;
                while (currentIndex >= 0 && currentIndex < fieldSize && ladyBugField[currentIndex] != 0)
                {
                    if (isFirst)
                    {
                        ladyBugField[currentIndex] = 0;
                        isFirst = false;
                    }
                    string direction = command[1];
                    int flightLength = int.Parse(command[2]);
                    if (direction == "left")
                    {
                        currentIndex -= flightLength;
                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladyBugField[currentIndex] == 0)
                            {
                                ladyBugField[currentIndex] = 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        currentIndex += flightLength;
                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladyBugField[currentIndex] == 0)
                            {
                                ladyBugField[currentIndex] = 1;
                                break;
                            }
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", ladyBugField));
        }
    }
}
