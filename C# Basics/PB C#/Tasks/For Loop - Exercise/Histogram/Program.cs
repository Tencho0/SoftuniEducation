using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int numsUnder200 = 0;
            int numsUnder400 = 0;
            int numsUnder600 = 0;
            int numsUnder800 = 0;
            int numsMoreThan800 = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num >= 800)
                {
                    numsMoreThan800++;
                }
                else if (num >= 600)
                {
                    numsUnder800++;
                }
                else if (num >= 400)
                {
                    numsUnder600++;
                }
                else if (num >= 200)
                {
                    numsUnder400++;
                }
                else if (num < 200)
                {
                    numsUnder200++;
                }
            }
            double p1 = 1.0* numsUnder200 / n * 100;
            double p2 = 1.0 * numsUnder400 / n * 100;
            double p3 = 1.0 * numsUnder600 / n * 100;
            double p4 = 1.0 * numsUnder800 / n * 100;
            double p5 = 1.0 * numsMoreThan800 / n * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
