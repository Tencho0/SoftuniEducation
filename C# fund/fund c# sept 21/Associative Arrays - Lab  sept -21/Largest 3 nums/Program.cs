using System;
using System.Linq;

namespace Largest_3_nums
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", Console.ReadLine().Split().Select(int.Parse).ToArray().OrderByDescending(n => n).Take(3)
                .ToArray()));
        }
    }
}
