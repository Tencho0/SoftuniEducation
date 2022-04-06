using System;
using System.Linq;

namespace T03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> func = x => x.Min();
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(func(arr));
        }
    }
}
