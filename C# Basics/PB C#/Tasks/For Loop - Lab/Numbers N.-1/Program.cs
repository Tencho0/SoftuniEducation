using System;

namespace Numbers_from_1_to_100
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int counter = int.Parse(Console.ReadLine()); counter >= 1; --counter-)
            {
                Console.WriteLine(counter);
            }
        }
    }
}
