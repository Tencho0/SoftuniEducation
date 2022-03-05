using System;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            string[] reversedArr = new string[arr.Length];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                reversedArr[i] = arr[arr.Length - i - 1];
            }
            Console.WriteLine(string.Join(" ", reversedArr));
        }
    }
}
