using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.TheLift_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            List<int> liftCount = Console.ReadLine().Split().Select(int.Parse).ToList();
            for (int i = 0; i < liftCount.Count; i++)
            {
                if (!(liftCount[i] == 4))
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (liftCount[i] == 4 || people <= 0) break;
                        liftCount[i]++;
                        people--;
                    }
                }
            }
            bool isEveryWagonFull = true;
            foreach (var item in liftCount)
            {
                if (!(item == 4))
                {
                    isEveryWagonFull = false;
                    break;
                }
            }
            if (people == 0 && !isEveryWagonFull)
            {
                Console.WriteLine($"The lift has empty spots!");
            }
            else if (people > 0 && isEveryWagonFull)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
            }
            Console.WriteLine(String.Join(" ", liftCount));
        }
    }
}
