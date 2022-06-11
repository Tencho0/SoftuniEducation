namespace T06.GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<double> list = new List<double>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                double cmd = double.Parse(Console.ReadLine());
                list.Add(cmd);
            }
            double comparableLine = double.Parse(Console.ReadLine());
            var box = new Box<double>(list);
            Console.WriteLine(box.CountOfGreaterElements(list, comparableLine));
        }
    }
}
