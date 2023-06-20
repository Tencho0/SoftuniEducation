namespace T01BinarySearch
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(numbers, number));
        }

        private static int BinarySearch(int[] numbers, int number)
        {
            var left = 0;
            var right = numbers.Length - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (numbers[mid] == number)
                {
                    return mid;
                }

                if (number > numbers[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
        //private static int BinarySearch(int[] numbers, int number)
        //{
        //    var start = 0;
        //    var end = numbers.Length - 1;

        //    while (start <= end)
        //    {
        //        var middle = (start + end) / 2;

        //        if (numbers[middle] == number)
        //        {
        //            return middle;
        //        }

        //        if (numbers[middle] < number)
        //        {
        //            start = middle + 1;
        //        }
        //        else
        //        {
        //            end = middle - 1;
        //        }
        //    }

        //    return -1;
        //}
    }
}