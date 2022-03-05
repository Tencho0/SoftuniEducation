using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfFloors = int.Parse(Console.ReadLine());
            int numOfRomms = int.Parse(Console.ReadLine());
            for (int floor = numOfFloors; floor >= 1; floor--)
            {
                for (int rooms = 0; rooms < numOfRomms; rooms++)
                {
                    if (floor == numOfFloors)
                    {
                        Console.Write($"L{floor}{rooms} ");
                        continue;
                    }
                    if (floor % 2 ==0)
                    {
                        Console.Write($"O{floor}{rooms} ");
                    }
                    else
                    {
                        Console.Write($"A{floor}{rooms} ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
