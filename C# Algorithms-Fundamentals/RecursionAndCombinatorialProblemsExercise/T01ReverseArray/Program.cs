namespace T01ReverseArray
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().ToArray();
            ReverseArray(arr, 0, arr.Length - 1);
        }

        private static void ReverseArray(string[] arr, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            var temp = arr[startIndex];
            arr[startIndex] = arr[endIndex];
            arr[endIndex] = temp;

            ReverseArray(arr, startIndex + 1, endIndex - 1);
        }
    }
}