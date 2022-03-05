using System;

namespace Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < times; i++)
            {
                int n1 = int.Parse(Console.ReadLine());
                sum1 += n1;
            }
            for (int i = 0; i < times; i++)
            {
                int n2 = int.Parse(Console.ReadLine());
                sum2 += n2;
            }
            if (sum1 == sum2)
            {
                Console.WriteLine($"Yes, sum = {sum1}");
            }
            else
            {
                double difference = Math.Abs(sum1 - sum2);
                Console.WriteLine($"No, diff = {difference}");
            }
        }
    }
}
