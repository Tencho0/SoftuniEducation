using System;
using System.Linq;

namespace T01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            Action<string> writer = x => Console.WriteLine(x);
            words.ForEach(writer);
        }
    }
}
