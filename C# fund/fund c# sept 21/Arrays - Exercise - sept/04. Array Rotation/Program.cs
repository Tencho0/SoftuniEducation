using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int temp = array[0];
                for (int i = 0; i < array.Length - 2; i++)
                {
                    array[i] = array[i + 1];
                }
                array[array.Length - 1] = temp;
            }
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
