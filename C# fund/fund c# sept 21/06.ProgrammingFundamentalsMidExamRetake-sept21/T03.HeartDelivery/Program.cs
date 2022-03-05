using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine().Split('@').Select(int.Parse).ToList();
            string command = Console.ReadLine();
            int currIndex = 0;
            while (command != "Love!")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int givenIndexToJump = int.Parse(givenCmd[1]);
                int indexToJump = givenIndexToJump + currIndex;
                if (indexToJump >= neighborhood.Count)
                {
                    indexToJump = 0;
                }
                neighborhood[indexToJump] -= 2;
                if (neighborhood[indexToJump] <= 0)
                {
                    Console.WriteLine($"Place {indexToJump} already had Valentine's day.");
                }
                if (neighborhood[indexToJump] == 0)
                {
                    Console.WriteLine($"Place {indexToJump} has Valentine's day.");
                }

                currIndex = indexToJump;
                command = Console.ReadLine();
            }
            Console.WriteLine($"Cupid's last position was {currIndex}.");
            int unsuccessfulNeighborhoods = 0;
            foreach (var item in neighborhood)
            {
                if (item != 0)
                {
                    unsuccessfulNeighborhoods++;
                }
            }
            if (unsuccessfulNeighborhoods == 0)
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {unsuccessfulNeighborhoods} places.");
            }
        }
    }
}
