using System;
using System.Collections.Generic;
using System.Linq;

namespace T102.ShootfortheWin
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
            while (command != "End")
            {
                int index = int.Parse(command);
                if (IsValidIndex(index, list))
                {
                    int indexValue = list[index];
                    list[index] = -1;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] != -1)
                        {
                            if (list[i] > indexValue)
                            {
                                list[i] -= indexValue;
                            }
                            else
                            {
                                list[i] += indexValue;
                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }
            int count = 0;
            foreach (var item in list)
            {
                if (item == -1)
                {
                    count++;
                }
            }
            Console.WriteLine($"Shot targets: {count} -> {string.Join(" ", list)}");
        }
        public static bool IsValidIndex(int index, List<int> list)
        {
            return index >= 0 && index < list.Count && list[index] != -1;
        }
    }
}
