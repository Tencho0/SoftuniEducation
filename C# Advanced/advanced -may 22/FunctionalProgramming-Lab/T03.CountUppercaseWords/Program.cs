using System;
using System.Linq;

namespace T03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
          //  Func<string, bool> func = x => char.IsUpper(x[0]);
            Console.WriteLine(
                string.Join("\r\n",
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => char.IsUpper(x[0]))
                .ToArray()));
        }
    }
}
