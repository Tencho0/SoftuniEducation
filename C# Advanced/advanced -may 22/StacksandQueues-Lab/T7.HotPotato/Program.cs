using System;
using System.Collections.Generic;

namespace T7.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] givenKids = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Queue<string> kids = new Queue<string>(givenKids);
            int count = int.Parse(Console.ReadLine());
            int reps = 1;
            while (kids.Count > 1)
            {
                string currKid = kids.Dequeue();
                if (reps % count == 0)
                {
                    Console.WriteLine($"Removed {currKid}");
                }
                else
                {
                    kids.Enqueue(currKid);
                }
                reps++;
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
