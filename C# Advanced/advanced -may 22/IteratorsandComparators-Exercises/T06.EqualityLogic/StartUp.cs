namespace T06.EqualityLogic
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        static void Main(string[] args)
        {
            var sortedSet = new SortedSet<Person>();
            var hashSet = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(cmd[0], int.Parse(cmd[1]));
                sortedSet.Add(person);
                hashSet.Add(person);
            }
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
