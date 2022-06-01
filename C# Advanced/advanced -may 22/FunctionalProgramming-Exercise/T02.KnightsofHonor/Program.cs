using System;
using System.Linq;

namespace T02.KnightsofHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = x => Console.WriteLine($"Sir {x}");
            Console.ReadLine()
                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                  .ToList()
                  .ForEach(action);
        }
    }
}
