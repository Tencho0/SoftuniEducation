
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<List<string>> finalLisst = new List<List<string>>();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                List<string> currList = list[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                finalLisst.Add(currList);
            }
            foreach (var item in finalLisst)
            {
                foreach (var item2 in item)
                {
                    Console.Write(item2 + " ");
                }
            }

            //List<string> numbersAsStrings = Console.ReadLine()
            //                      .Split('|')
            //                      .Reverse()
            //                      .ToList();
            //List<int> numbers = new List<int>();
            //foreach (var str in numbersAsStrings)
            //{
            //    numbers.AddRange(str.Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //                        .Select(int.Parse)
            //                        .ToList());
            //}
            //Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
