using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Action<int[]> add = x =>
            //{
            //    for (int i = 0; i < x.Length; i++)
            //        x[i] += 1;
            //};
            //Action<int[]> subtract = x =>
            //{
            //    for (int i = 0; i < x.Length; i++)
            //        x[i] -= 1;
            //};
            //Action<int[]> multiply = x =>
            //{
            //    for (int i = 0; i < x.Length; i++)
            //        x[i] *= 2;
            //};
            //Action<int[]> print = x =>
            //{
            //    Console.WriteLine(string.Join(" ", x));
            //};

            Func<int[], int[]> multiply = x => x.Select(y => y * 2).ToArray();
            Func<int[], int[]> add = x => x.Select(y => y + 1).ToArray();
            Func<int[], int[]> subtract = x => x.Select(y => y - 1).ToArray();
            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));

            var nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add": nums = add(nums); break;
                    case "multiply": nums = multiply(nums); break;
                    case "subtract": nums = subtract(nums); break;
                    case "print": print(nums); break;
                }
                command = Console.ReadLine();
            }

            //Func<int, int> multiply = x => x * 2;
            //Func<int, int> add = x => x + 1;
            //Func<int, int> subtract = x => x - 1;

            //var nums = Console.ReadLine()
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToList();

            //string command = Console.ReadLine();
            //while (command != "end")
            //{
            //    switch (command)
            //    {
            //        case "add":
            //            nums = nums.Select(add).ToList();
            //            break;
            //        case "multiply":
            //            nums = nums.Select(multiply).ToList();
            //            break;
            //        case "subtract":
            //            nums = nums.Select(subtract).ToList();
            //            break;
            //        case "print":
            //            Console.WriteLine(string.Join(" ", nums));
            //            break;
            //    }
            //    command = Console.ReadLine();
            //}
        }
    }
}
