using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.GenericCountMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                box.Items.Add(input);
            }
            string value = Console.ReadLine();
            Console.WriteLine(box.ComparisonCount(value));
        }
    }
}
