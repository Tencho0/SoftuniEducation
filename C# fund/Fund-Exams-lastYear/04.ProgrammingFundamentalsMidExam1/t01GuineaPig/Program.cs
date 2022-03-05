using System;

namespace t01GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine()) * 1000;
            double hay = double.Parse(Console.ReadLine()) * 1000;
            double cover = double.Parse(Console.ReadLine()) * 1000;
            double weight = double.Parse(Console.ReadLine()) * 1000;
            int currDay = 0;

            while (currDay != 30)
            {
                currDay++;
                food -= 300;
                if (currDay % 2 == 0)
                {
                    hay -= (food * 0.05);
                }
                if (currDay % 3 == 0)
                {
                    cover -= (weight / 3.0);
                }
                if (food <= 0 || hay <= 0 || cover <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }
            food /= 1000.00;
            hay /= 1000.00;
            cover /= 1000.00;
            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:F2}, Hay: {hay:F2}, Cover: {cover:F2}.");
        }
    }
}
