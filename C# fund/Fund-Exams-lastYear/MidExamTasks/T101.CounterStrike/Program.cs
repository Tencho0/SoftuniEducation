using System;

namespace T101.CounterStrike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            string command = string.Empty;
            int count = 0;
            while (initialEnergy >= 0)
            {
                command = Console.ReadLine();
                if (command == "End of battle")
                {
                    break;
                }
                int currCmd = int.Parse(command);
                if (currCmd > initialEnergy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {initialEnergy} energy");
                }
                initialEnergy -= currCmd;
                count++;
                if (count % 3 == 0)
                {
                    initialEnergy += count;
                }
            }
            if (initialEnergy >= 0)
            {
                Console.WriteLine($"Won battles: {count}. Energy left: {initialEnergy}");
            }
        }
    }
}
