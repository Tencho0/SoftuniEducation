using System;
using System.Numerics;

namespace T07.Wires
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            BigInteger bgint = new BigInteger();
            bgint = 1;
            long reps = n * m;
            reps /= 4;
            for (int i = 1; i < reps; i++)
            {
                bgint *= i;
            }
            Console.WriteLine(bgint % 1000003);
        }
    }
}
