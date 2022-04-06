using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.FindEvensorOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string evenOrOdd = Console.ReadLine();
           
            var list = new List<int>();
            for (int i = input[0]; i <= input[1]; i++)
            {
                list.Add(i);
            }

            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;

            if (evenOrOdd == "even")
            {
                list = list.FindAll(isEven);
            }
            else
            {
                list = list.FindAll(isOdd);
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
