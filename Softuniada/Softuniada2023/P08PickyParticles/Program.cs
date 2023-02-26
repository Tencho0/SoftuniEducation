using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var matrix1 = ReadMatrix(n);
        var matrix2 = ReadMatrix(n);

        Dictionary<int, int> countDict = new Dictionary<int, int>();

        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix1.GetLength(1); j++)
            {
                if (matrix1[i, j] == matrix2[i, j])
                {
                    if (countDict.ContainsKey(matrix1[i, j]))
                    {
                        countDict[matrix1[i, j]]++;
                    }
                    else
                    {
                        countDict[matrix1[i, j]] = 1;
                    }
                }
            }
        }

        foreach (KeyValuePair<int, int> kvp in countDict.OrderByDescending(x=> x.Value))
        {
            Console.WriteLine($"{kvp.Key} <-> {kvp.Value}");
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