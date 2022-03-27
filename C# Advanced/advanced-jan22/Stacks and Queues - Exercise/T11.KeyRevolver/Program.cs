using System;
using System.Collections.Generic;
using System.Linq;

namespace T11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] inputBullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputLocks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(inputBullets);
            Queue<int> locks = new Queue<int>(inputLocks);
            int currShoots = gunBarrel;
            int bulletsCount = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int bullet = bullets.Pop();
                int currLock = locks.Peek();

                currShoots--;
                bulletsCount++;

                if (bullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (currShoots == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    currShoots = gunBarrel;
                }
            }
            if (locks.Count> 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int result = intelligence - (bulletsCount * bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${result}");
            }
        }
    }
}
