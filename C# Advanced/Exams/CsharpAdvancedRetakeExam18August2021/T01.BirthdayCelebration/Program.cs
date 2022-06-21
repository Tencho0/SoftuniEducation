using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] givenEating = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] givenPlates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> plates = new Stack<int>(givenPlates);
            Queue<int> guests = new Queue<int>(givenEating);

            int wastedFood = 0;
            int currGuest = guests.Peek();
            while (plates.Count > 0 && guests.Count > 0)
            {
                int currPlate = plates.Pop();
                currGuest -= currPlate;
                if (currGuest <= 0)
                {
                    wastedFood += (currGuest * -1);
                    guests.Dequeue();
                    if (guests.Count > 0)
                        currGuest = guests.Peek();
                }
            }
            if (plates.Count > 0)
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            if (guests.Count > 0)
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
