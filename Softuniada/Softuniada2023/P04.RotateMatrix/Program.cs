using System;

class Program
{
    static void Main(string[] args)
    {
        int matrixLength = int.Parse(Console.ReadLine());
        int[,] matrix = ReadMatrix(matrixLength);

        int[,] rotatedMatrix = RotateMatrix(matrix);

        PrintMatrix(rotatedMatrix);
    }

    static int[,] RotateMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int[,] rotatedMatrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                rotatedMatrix[j, n - i - 1] = matrix[i, j];
            }
        }

        return rotatedMatrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    private static int[,] ReadMatrix(int matrixLength)
    {
        int rows = matrixLength;
        int columns = matrixLength;
        int[,] matrix = new int[rows, columns];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int col = 0; col < currRow.Length; col++)
            {
                matrix[row, col] = currRow[col];
            }
        }

        return matrix;
    }
}