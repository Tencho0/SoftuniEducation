namespace T04.GenericSwapMethodInteger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int cmd = int.Parse(Console.ReadLine());
                list.Add(cmd);
            }

            var arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var box = new Box<int>(list);
            box.Swap(list, arr[0], arr[1]);
            Console.WriteLine(box);
        }
    }
}
