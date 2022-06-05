namespace T09.PredicateParty_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .ToList();
            string command = Console.ReadLine();
            while (command != "Party!")
            {


                command = Console.ReadLine();
            }
        }
    }
}
