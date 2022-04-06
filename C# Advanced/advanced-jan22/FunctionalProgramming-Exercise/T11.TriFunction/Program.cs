using System;
using System.Linq;

namespace T11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> func = (x, y) => x.Sum(x => x) >= y;
            Func<string[], Func<string, int, bool>,int, string> takeName =
                (arr, func1, n) => arr.Where(x=> func1(x, n)).First();

            int n = int.Parse(Console.ReadLine());
            string[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Console.WriteLine(takeName(arr, func, n));
        }
    }
}
