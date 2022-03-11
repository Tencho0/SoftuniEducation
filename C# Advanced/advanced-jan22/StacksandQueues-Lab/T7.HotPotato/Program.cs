using System;
using System.Collections.Generic;

namespace T7.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> players =
                new Queue<string>(Console.ReadLine().Split());
            int n = int.Parse(Console.ReadLine());
            int reps = 1;
            while (players.Count != 1)
            {
                if (reps % n == 0)
                {
                    Console.WriteLine($"Removed {players.Dequeue()}");
                }
                else
                {
                    string player = players.Dequeue();
                    players.Enqueue(player);
                   // players.Enqueue(players.Dequeue());
                }
                reps++;
            }
            Console.WriteLine($"Last is {players.Dequeue()}");
        }
    }
}
