using System;

namespace cake1
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int allPeacesOfCake = lenght * width;

            while (allPeacesOfCake > 0)
            {
                string input = Console.ReadLine();
                if (input == "STOP")
                {
                    break;
                }
                    int peaceOfCake = int.Parse(input);
                    allPeacesOfCake -= peaceOfCake;
            }

            if (allPeacesOfCake >= 0)
            {
                Console.WriteLine($"{allPeacesOfCake} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(allPeacesOfCake)} pieces more.");
            }
        }
    }
}
