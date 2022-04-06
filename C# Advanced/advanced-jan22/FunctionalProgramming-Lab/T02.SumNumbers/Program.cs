using System;
using System.Linq;

namespace T02.SumNumbers
{
    internal class Program
    {
        //static int Parse(string x)
        //{
        //    return int.Parse(x);
        //}
        static void Main(string[] args)
        {
           // Func<string, int> parser = Parse;
            Func<string, int> parser = x => int.Parse(x);
            var nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();
            Console.WriteLine(nums.Length);
            Console.WriteLine(nums.Sum());

            //int[] nums = Console.ReadLine()
            //    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();
            //Func<int[], int> func = FindCount;
            //Func<int[], int> sumFunc = Sum;
            //Console.WriteLine(func(nums));
            //Console.WriteLine(sumFunc(nums));

        }

        //static int FindCount(int[] nums)
        //{
        //    int count = 0;
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        count++;
        //    }
        //    return count;
        //}
        //static int Sum(int[] nums)
        //{
        //    int sum = 0;
        //    foreach (var num in nums)
        //    {
        //        sum += num;
        //    }
        //    return sum;
        //}
    }
}
