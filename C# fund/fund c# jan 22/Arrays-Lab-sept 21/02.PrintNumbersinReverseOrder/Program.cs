using System;

namespace _02.PrintNumbersinReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int reps = int.Parse(Console.ReadLine());
            string[] arr = new string[reps];
            for (int i = reps -1; i >= 0; i--)
            {
                arr[i] = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
