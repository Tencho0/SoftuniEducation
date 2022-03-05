using System;

namespace Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxNum = int.MinValue;
            int sumOfAnother = 0;
            int difference = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num > maxNum)
                {
                    maxNum = num;
                }
                sumOfAnother += num;
            }
            sumOfAnother -= maxNum;
            if (maxNum == sumOfAnother)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxNum}");
            }
            else
            {
                difference = Math.Abs(maxNum - sumOfAnother);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {difference}");
            }
        }
    }
}
