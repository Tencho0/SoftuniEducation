using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladyBugsIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] field = new int[fieldSize];
            for (int index = 0; index < fieldSize; index++)
            {
                if (ladyBugsIndexes.Contains(index))
                {
                    field[index] = 1;
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                int initialIndex = int.Parse(cmdArgs[0]);
                string direction = cmdArgs[1];
                int flyLength = int.Parse(cmdArgs[2]);
                //Chek is valid 
                if (initialIndex < 0 || initialIndex >= field.Length)
                {
                    continue;
                }
                // we have valid index, then we chek if there is a ladybug
                if (field[initialIndex] == 0)
                {
                    continue;
                }
                field[initialIndex] = 0;
                int nextIndex = initialIndex;
                while (true)
                {
                    if (direction == "right")
                    {
                        nextIndex += flyLength;
                    }
                    else if (direction == "left")
                    {
                        nextIndex -= flyLength;
                    }
                    nextIndex += flyLength;
                    if (nextIndex < 0 || nextIndex >= field.Length)
                    {
                        break;
                    }
                    if (field[nextIndex] == 0)
                    {
                        break;
                    }
                }
                if (nextIndex >= 0 && nextIndex <= field.Length)
                {
                    field[nextIndex] = 1;
                }
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
