using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            int totalSpace = a * b * h;

            while (totalSpace > 0)
            {
                string input = Console.ReadLine();
                if (input == "Done")
                {
                    break;
                }
                int oneBox = int.Parse(input);
                totalSpace -= oneBox;
            }
            if (totalSpace <= 0)
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(totalSpace)} Cubic meters more.");
            }
            else
            {
                Console.WriteLine($"{totalSpace} Cubic meters left.");
            }

        }
    }
}
