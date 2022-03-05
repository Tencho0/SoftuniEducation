using System;
using System.Collections.Generic;
using System.Linq;

namespace ListsFundamentals_sept21
{
    class Program
    {
        static void Main(string[] args)
        {


            List<int> list = new List<int>
            {
                44, 21, 5, 33, 17, 4, 13, 1
            };
            for (int i = 0; i < list.Count; i++)
            {
                int min = i;
                for (int j = i; j < list.Count; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }
                int temp = list[i];
                list[i] = list[min];
                list[min] = temp;
            }
            Console.WriteLine(string.Join(" ", list));



            List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            for (int i = 0; i < n; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
