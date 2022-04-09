using System;

namespace T06.GenericCountMethodDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Items.Add(input);
            }
            double value = double.Parse(Console.ReadLine());
            Console.WriteLine(box.ComparisonCount(value));
        }
    }
}
