using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double maxSum = int.MinValue;
            string maxSumModel = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string modelOfKeg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double currSum = Math.PI * radius * radius * height;
                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    maxSumModel = modelOfKeg;
                }
            }
                Console.WriteLine(maxSumModel);
        }
    }
}
