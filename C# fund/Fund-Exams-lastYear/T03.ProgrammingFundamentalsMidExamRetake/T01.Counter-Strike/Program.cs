using System;

namespace T01.Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string command = string.Empty;
            int wins = 0;
            int distance = 0;
            while (energy >= 0)
            {
                command = Console.ReadLine();
                if (command == "End of battle")
                {
                    break;
                }
                else
                {
                    distance = int.Parse(command);
                    if (distance > energy)
                    {
                        Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
                    }
                    energy -= distance;
                    wins++;
                    if (wins % 3 == 0)
                    {
                        energy += wins;
                    }
                }
            }
            if (energy >= 0)
            {
                Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
            }
        }
    }
}
