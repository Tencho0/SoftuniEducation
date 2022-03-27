using System;
using System.Linq;

namespace T6.JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            // int[][] matrix = ReadArr(rows);
            int[][] joggedArray = ReadJaggedArray(rows);

            // ModifyArr(matrix);
            ModifyJoggedArray(joggedArray);

            // PrintResult(matrix);
            PrintResult(joggedArray);
        }
        static void PrintResult(int[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
        static int[][] ReadJaggedArray(int rows)
        {
            int[][] jagged = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                jagged[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            return jagged;
        }
        static int[][] ReadArr(int rows)
        {
            int[][] matrix = new int[rows][];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                matrix[row] = new int[currRow.Length];
                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row][col] = currRow[col];
                }
            }
            return matrix;
        }
        static void ModifyArr(int[][] matrix)
        {
            string cmd = Console.ReadLine();
            while (cmd != "END")
            {
                string[] givenCmd = cmd.Split();
                string action = givenCmd[0];
                int row = int.Parse(givenCmd[1]);
                int col = int.Parse(givenCmd[2]);
                int value = int.Parse(givenCmd[3]);

                if (row < 0 || row > matrix.GetLength(0) - 1 || col < 0 || col > matrix[row].Length - 1)
                {
                    Console.WriteLine($"Invalid coordinates");
                    cmd = Console.ReadLine();
                    continue;
                }

                if (action == "Add")
                {
                    matrix[row][col] += value;
                }
                else if (action == "Subtract")
                {
                    matrix[row][col] -= value;
                }
                cmd = Console.ReadLine();
            }
        }
        static void ModifyJoggedArray(int[][] joggedArray)
        {
            string cmd = Console.ReadLine();
            while (cmd != "END")
            {
                string[] givenCmd = cmd.Split();
                string action = givenCmd[0];
                int row = int.Parse(givenCmd[1]);
                int col = int.Parse(givenCmd[2]);
                int value = int.Parse(givenCmd[3]);

                if (row < 0 || col < 0 || row >= joggedArray.Length || col >= joggedArray[row].Length)
                {
                    Console.WriteLine($"Invalid coordinates");
                }
                else if (action == "Add")
                {
                    joggedArray[row][col] += value;
                }
                else if (action == "Subtract")
                {
                    joggedArray[row][col] -= value;
                }

                cmd = Console.ReadLine();
            }
        }
    }
}
