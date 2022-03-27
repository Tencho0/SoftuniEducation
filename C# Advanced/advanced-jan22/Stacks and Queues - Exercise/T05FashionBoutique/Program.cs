using System;
using System.Collections.Generic;
using System.Linq;

namespace T05FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputClothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> clothes = new Stack<int>(inputClothes);
            int racks = 1;
            int countOfClothes = 0;

            while (clothes.Count > 0)
            {
                countOfClothes += clothes.Peek();
                if (countOfClothes <= capacity)
                {
                    clothes.Pop();
                }
                else
                {
                    racks++;
                    countOfClothes = 0;
                }
            }
            Console.WriteLine(racks);
        }
    }
}
