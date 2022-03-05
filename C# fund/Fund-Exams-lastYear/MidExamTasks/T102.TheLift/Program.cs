using System;
using System.Collections.Generic;
using System.Linq;

namespace T102.TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waitingPeople = int.Parse(Console.ReadLine());
            List<int> people = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i] != 4)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (people[i] == 4 || waitingPeople <= 0) break;
                        people[i]++;
                        waitingPeople--;
                    }
                }
            }
            bool isEveryWagonFull = true;
            foreach (var item in people)
            {
                if (item < 4)
                {
                    isEveryWagonFull = false;
                }
            }
            if (waitingPeople == 0 && !isEveryWagonFull)
            {
                Console.WriteLine($"The lift has empty spots!");
            }
            else if (waitingPeople > 0 && isEveryWagonFull)
            {
                Console.WriteLine($"There isn't enough space! {waitingPeople} people in a queue!");
            }
            Console.WriteLine(string.Join(" ", people));
        }
    }
}
