using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGuests = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();
            for (int i = 0; i < numberOfGuests; i++)
            {
                string[] guest = Console.ReadLine().Split();
                if (guest.Contains("not"))
                {
                    if (names.Contains(guest[0]))
                    {
                        names.Remove(guest[0]);
                        continue;
                    }
                    Console.WriteLine($"{guest[0]} is not in the list!");
                    continue;
                }
                if (names.Contains($"{guest[0]}"))
                {
                    Console.WriteLine($"{guest[0]} is already in the list!");
                }
                if (true)
                {
                    if (names.Contains(guest[0])) continue;
                    names.Add(guest[0]);
                }
            }
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
