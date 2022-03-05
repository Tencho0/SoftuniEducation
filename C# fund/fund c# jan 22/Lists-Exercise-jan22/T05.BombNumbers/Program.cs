using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombDetonation = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int specialNum = bombDetonation[0];
            int power = bombDetonation[1];
            for (int i = 0; i < list.Count; i++)
            {
                int currNum = list[i];
                if (currNum == specialNum)
                {
                    for (int j = i- power; j <= i+ power; j++)
                    {
                        if (j < 0 || j >= list.Count)
                        {
                            continue;
                        }
                        list[j] = 0;
                    }
                }
            }
            Console.WriteLine(list.Sum());
        }
    }
}
