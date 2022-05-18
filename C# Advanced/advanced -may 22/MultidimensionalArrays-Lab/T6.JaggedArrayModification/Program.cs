using System;
using System.Linq;

namespace T6.JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArr = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArr[i] = currRow;
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                int row = int.Parse(givenCmd[1]);
                int col = int.Parse(givenCmd[2]);
                int givenValue = int.Parse(givenCmd[3]);

                if (IsGivenIndiciesValid(row, col, jaggedArr))
                {
                    Calculate(jaggedArr, action, row, col, givenValue);
                }
                else
                {
                    Console.WriteLine($"Invalid coordinates");
                }

                command = Console.ReadLine();
            }


            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArr[i])); ;
            }

        }
        public static bool IsGivenIndiciesValid(int row, int col, int[][] jaggedArr)
        {
            return row >= 0 && col >= 0 && jaggedArr.GetLength(0) > row && jaggedArr[row].Length > col;
        }

        public static void Calculate(int[][] jaggedArr, string action, int row, int col, int givenValue)
        {
            if (action == "Add")
            {
                jaggedArr[row][col] += givenValue;
            }
            else if (action == "Subtract")
            {
                jaggedArr[row][col] -= givenValue;
            }

        }
    }
}
