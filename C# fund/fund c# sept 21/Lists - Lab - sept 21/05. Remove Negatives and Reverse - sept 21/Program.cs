using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Result(numbers);
            //numbers.RemoveAll(n => n < 0);
            //if (numbers.Count == 0)
            //{
            //    Console.WriteLine("empty");
            //}
            //else
            //{
            //    for (int i = 0; i < numbers.Count / 2; i++)
            //    {
            //        int temp = numbers[i];
            //        numbers[i] = numbers[numbers.Count - 1 - i];
            //        numbers[numbers.Count - 1 - i] = temp;
            //    }
            //    Console.WriteLine(string.Join(" ", numbers));
            //}
        }
        static void Result(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] <0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            list.Reverse();
            if (list.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else Console.WriteLine(string.Join(" ", list));
        }
    }
}
