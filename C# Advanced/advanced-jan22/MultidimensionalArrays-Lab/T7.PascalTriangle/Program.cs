using System;

namespace T7.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] joggedArr = new long[rows][];
            joggedArr[0] = new long[1] { 1 };
            for (int row = 1; row < rows; row++)
            {
                joggedArr[row] = new long[joggedArr[row - 1].Length + 1];
                for (int col = 0; col < joggedArr[row].Length; col++)
                {
                    if (joggedArr[row - 1].Length > col)
                    {
                        joggedArr[row][col] += joggedArr[row - 1][col];
                    }
                    if (col > 0)
                    {
                        joggedArr[row][col] += joggedArr[row - 1][col - 1];
                    }
                }
            }
            for (long row = 0; row < joggedArr.Length; row++)
            {
                Console.WriteLine(string.Join(" ", joggedArr[row]));
            }
        }
    }
}
