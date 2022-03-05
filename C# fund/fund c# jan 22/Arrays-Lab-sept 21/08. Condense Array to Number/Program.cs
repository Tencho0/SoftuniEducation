using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int arrLenght = arr.Length;
            for (int i = 0; i < arrLenght- 1; i++)
            {
                int[] newArr = new int[arr.Length - 1];
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    newArr[j] = arr[j] + arr[j + 1];
                }
                arr = newArr;
            }
            Console.WriteLine(arr[0]);
        }
    }
}
