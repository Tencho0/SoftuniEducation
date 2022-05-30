using System;
using System.Linq;

namespace T01.SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
               string.Join(", ",
               Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x=>x)
                ));
        }
    }
}
