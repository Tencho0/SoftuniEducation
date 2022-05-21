using System;
using System.Collections.Generic;
using System.Linq;

namespace T11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int price = int.Parse(Console.ReadLine());
            int sizeOfBarrel = int.Parse(Console.ReadLine());
            int[] bulletsArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locksArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsArray);
            Queue<int> locks = new Queue<int>(locksArray);

            int currShots = sizeOfBarrel;
            int bulletsCount = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int currBullet = bullets.Pop();
                int currLock = locks.Peek();

                currShots--;
                bulletsCount++;

                if (currBullet <= currLock)
                {
                    Console.WriteLine($"Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (currShots <= 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    currShots = sizeOfBarrel;
                }
            }
            if (bullets.Count == 0 && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int result = intelligence - (bulletsCount * price);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${result}");
            }
        }
    }
}
