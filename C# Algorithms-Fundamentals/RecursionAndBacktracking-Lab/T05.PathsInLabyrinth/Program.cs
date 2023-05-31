namespace T05.PathsInLabyrinth
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            var lab = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var colElements = Console.ReadLine();

                for (int col = 0; col < colElements.Length; col++)
                {
                    lab[row, col] = colElements[col];
                }
            }

            FindPaths(lab, 0, 0, new List<string>(), string.Empty);
        }

        private static void FindPaths(char[,] lab, int row, int col, List<string> directions, string direction)
        {
            if (IsValid(lab, row, col))
            {
                return;
            }

            if (lab[row, col] == '*' || lab[row, col] == 'v')
            {
                return;
            }

            directions.Add(direction);

            if (lab[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            lab[row, col] = 'v';

            FindPaths(lab, row - 1, col, directions, "U");
            FindPaths(lab, row + 1, col, directions, "D");
            FindPaths(lab, row, col - 1, directions, "L");
            FindPaths(lab, row, col + 1, directions, "R");

            lab[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }

        private static bool IsValid(char[,] lab, int row, int col)
            => row < 0 || row >= lab.GetLength(0) || col < 0 || col >= lab.GetLength(1);
    }
}