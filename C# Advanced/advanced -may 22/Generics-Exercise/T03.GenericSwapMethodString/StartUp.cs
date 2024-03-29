﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string cmd = Console.ReadLine();
                list.Add(cmd);
            }

            var arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var box = new Box<string>(list);
            box.Swap(list, arr[0], arr[1]);
            Console.WriteLine(box);
        }
    }
}
