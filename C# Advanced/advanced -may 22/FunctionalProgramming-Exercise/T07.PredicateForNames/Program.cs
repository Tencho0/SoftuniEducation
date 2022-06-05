using System;
using System.Linq;

namespace T07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length <= n)
                .ToArray()));
        }
    }
}
