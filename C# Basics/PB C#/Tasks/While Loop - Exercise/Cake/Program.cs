using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int numCake = a * b;
            int moreCake = 0;
            int available = numCake;
            while (moreCake < numCake)
            {
                string input = Console.ReadLine();
                if (input != "Stop")
                {
                    int cakePart = int.Parse(input);
                    available -= cakePart;
                    if (available <= 0)
                    {
                        break;
                    }
                }
                else if(input == "Stop")
                {
                    moreCake = numCake - available;
                    Console.WriteLine($"{moreCake} pieces are left.");
                    break;
                }
            }

            if (available <= 0)
            {
                available = Math.Abs(available);
                Console.WriteLine($"No more cake left! You need {available:F0} pieces more.");
            }
        }
    }
}
