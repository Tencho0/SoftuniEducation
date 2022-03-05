using System;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] people = new int[numberOfWagons];
            int sum = 0;
            for (int i = 0; i < numberOfWagons; i++)
            {
                int currPeople = int.Parse(Console.ReadLine());
                people[i] = currPeople;
                sum += currPeople;
            }
            Console.WriteLine(string.Join(" ", people));
            Console.WriteLine(sum);
        }
    }
}
