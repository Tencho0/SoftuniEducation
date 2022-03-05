using System;

namespace _02._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(1);
            if (n == 1)
            {
                return;
            }

            int[] initialArray = new int[] { 1, 1 };
            Console.WriteLine(string.Join(" ", initialArray));
            if (n == 2)
            {
                return;
            }
            else
            {
                for (int i = 0; i < initialArray.Length + 1; i++)
                {
                    int[] array = new int[initialArray.Length + 1];
                    array[0] = 1;
                    array[array.Length - 1] = 1;
                    for (int j = 1; j < array.Length - 1; j++)
                    {
                        array[j] = initialArray[j - 1] + initialArray[j];
                    }
                    initialArray = array;
                    Console.WriteLine(string.Join(" ", array));
                    if (initialArray.Length == n)
                    {
                        break;
                    }
                }
            }
        }
    }
}
