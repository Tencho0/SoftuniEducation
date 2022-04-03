using System;
using System.Linq;

namespace T03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] givenArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            givenArr = givenArr.OrderByDescending(x => x).Take(3).ToArray();
            Console.WriteLine(string.Join(" ", givenArr));

            // givenArr = givenArr.OrderByDescending(x => x).ToArray();
            //if (givenArr.Length > 3)
            //{
            //    for (int i = 0; i < 3; i++)
            //    {
            //        Console.Write($"{givenArr[i]} ");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(string.Join(" ", givenArr));
            //}
        }
    }
}
