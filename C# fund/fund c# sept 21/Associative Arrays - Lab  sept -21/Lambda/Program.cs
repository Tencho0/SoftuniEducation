using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            list = list.Where(x => x % 2 == 0).ToList();
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
