using System;

namespace _10._Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            for (int i = n2; i <= 10; i++)
            {
                Console.WriteLine($"{n} X {i} = {n * i}");
            }
            if (n2 > 10)
            {
                Console.WriteLine($"{n} X {n2} = {n * n2}");
            }
        }
    }
}
