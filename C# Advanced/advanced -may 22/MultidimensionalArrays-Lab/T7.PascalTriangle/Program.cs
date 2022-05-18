using System;

namespace T7.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long[][] triangle = new long[n][];

            triangle[0] = new long[1] { 1 };

            for (int i = 1; i < triangle.GetLength(0); i++)
            {
                triangle[i] = new long[triangle[i - 1].Length + 1];

                for (int k = 0; k < triangle[i].Length; k++)
                {
                    if (triangle[i - 1].Length > k)
                    {
                        triangle[i][k] += triangle[i - 1][k];
                    }
                    if (k > 0)
                    {
                        triangle[i][k] += triangle[i - 1][k - 1];
                    }
                }
            }

            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(" ", triangle[i]));
            }
        }
    }
}
