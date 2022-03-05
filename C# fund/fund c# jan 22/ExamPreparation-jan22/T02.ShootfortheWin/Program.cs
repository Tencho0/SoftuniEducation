using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.ShootfortheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();
            int count = 0;

            while (command != "End")
            {
                int index = int.Parse(command);
                if (IsIndexValid(index, list))
                {
                    ShotTheTarget(index, list);
                    count++;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {count} -> {string.Join(" ", list)}");
        }
        static bool IsIndexValid(int index, List<int> list)
        {
            return index >=0 && index < list.Count;
        }
        static void ShotTheTarget(int index, List<int> list)
        {
            int currValie = list[index];
            list[index] = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == -1)
                {
                    continue;
                }
                if (list[i] > currValie)
                {
                    list[i] -= currValie;
                }
                else if(list[i] <= currValie)
                {
                    list[i] += currValie;
                }
            }
        }
    }
}
