using System;

namespace Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double capacityOfTheAquarium = length * width * height;
            double capacityLiters = capacityOfTheAquarium * 0.001;
            double percentOfUsedPlace = percent / 100;
            double litersOfWater = capacityLiters * (1 - percentOfUsedPlace);

            Console.WriteLine(litersOfWater);
            
        }
    }
}
