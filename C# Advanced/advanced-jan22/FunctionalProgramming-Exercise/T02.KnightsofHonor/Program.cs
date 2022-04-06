using System;
using System.Linq;

namespace T02.KnightsofHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            Action<string> writer = x => Console.WriteLine($"Sir {x}");
            names.ForEach(writer);
        }
    }
}
