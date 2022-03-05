using System;
using System.Collections.Generic;

namespace _04._List_of_Products___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfProducts = int.Parse(Console.ReadLine());
            List<string> Products = new List<string>();
            for (int i = 0; i < numberOfProducts; i++)
            {
                Products.Add(Console.ReadLine());
            }
            // Products.Sort();
            SelectionSort(Products);
            for (int i = 1; i <= Products.Count; i++)
            {
                Console.WriteLine($"{i}.{Products[i - 1]}");
            }
        }
        static void SelectionSort(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var min = i;
                for (int j = i+1; j < list.Count; j++)
                {
                    if (list[min].CompareTo(list[j]) > 0 )
                    {
                        min = j;
                    }
                }
                var temp = list[i];
                list[i] = list[min];
                list[min] = temp;
            }
        }
    }
}
