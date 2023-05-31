namespace T03.Generating01Vectors
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var arr = new int[n];

            Gen01Vectors(arr, 0);
        }

        private static void Gen01Vectors(int[] arr, int idx)
        {
            if (idx >= arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[idx] = i;
                Gen01Vectors(arr, idx + 1);
            }
        }
    }
}