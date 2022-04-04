using System;
using System.Collections.Generic;

namespace T01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string userName = Console.ReadLine();
                set.Add(userName);
            }
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
