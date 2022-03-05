using System;
using System.Linq;

namespace _04._Word_Filter_sept21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("\n",Console.ReadLine()
                .Split()
                .Where(x => x.Length % 2 == 0)
                .ToArray()));

            //string[] arr = Console.ReadLine()
            //    .Split()
            //    .Where(x => x.Length % 2 == 0)
            //    .ToArray();
            //Console.WriteLine(string.Join("\n", arr));
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
