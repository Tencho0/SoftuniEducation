using System;

namespace Computer_Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            double allAverageMore = 0;
            double possibleSels = 0;
            for (int i = 0; i < num; i++)
            {
                int num22 = int.Parse(Console.ReadLine());
                int rating = num22 % 10;
                if (rating == 2)
                {
                    possibleSels += (num22 / 10) * 0;
                }
                else if (rating == 3)
                {
                    possibleSels += (num22 / 10) / 2;
                }
                else if (rating == 4)
                {
                    possibleSels += (num22 / 10)  * 0.7;
                }
                else if (rating == 5)
                {
                    possibleSels += (num22 / 10) * 0.85;
                }
                else if (rating == 6)
                {
                    possibleSels += (num22 / 10);
                }
                allAverageMore += (num22 % 10);
            }
            double averageMore = allAverageMore / num * 1.0;

            Console.WriteLine($"{possibleSels:f2}");
            Console.WriteLine($"{averageMore:f2}");
        }
    }
}
