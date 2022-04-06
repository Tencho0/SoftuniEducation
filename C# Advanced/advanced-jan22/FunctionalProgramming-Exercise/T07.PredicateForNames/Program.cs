using System;
using System.Linq;

namespace T07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Func<string, int, bool> func = (x, y) => x.Length <= y;
            string[] givenNames = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            givenNames.Where(x => func(x, n)).ToList().ForEach( x=> Console.WriteLine(x));

        }
    }
}
