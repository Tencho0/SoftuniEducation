using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int reps = int.Parse(Console.ReadLine());
            int capacity = 0;
            for (int i = 0; i < reps; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                if (capacity + liters > byte.MaxValue)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    capacity += liters;
                }
            }
            Console.WriteLine(capacity);
        }
    }
}
