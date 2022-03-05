using System;

namespace _11._MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            if (end <= 10)
            {
                for (int i = end; i <= 10; i++)
                {
                    Console.WriteLine($"{start} X {i} = {start * i}");
                }
            }
            else
            {
                Console.WriteLine($"{start} X {end} = {start * end}");
            }
        }
    }
}
