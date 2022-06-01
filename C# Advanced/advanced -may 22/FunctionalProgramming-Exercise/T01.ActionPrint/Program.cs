using System;
using System.Linq;

namespace T01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = x => Console.WriteLine(x);
            Console.ReadLine()
                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                  .ToList()
                  .ForEach(action);
        }
    }
}
