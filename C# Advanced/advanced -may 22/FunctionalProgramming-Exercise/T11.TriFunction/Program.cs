using System;
using System.Linq;

namespace T11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Func<string, int, bool> func = (x, y) => x.Sum(x=> x) >= y;
            Func<string[], Func<string, int, bool>, int, string> func1 = (x, func, y) => x.First(z => func(z, y));
            Console.WriteLine(func1(names, func, n));
        }
    }
}
