using System;
using System.Linq;

namespace _05._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] % 2== 0)
                {
                    sum += sequence[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
