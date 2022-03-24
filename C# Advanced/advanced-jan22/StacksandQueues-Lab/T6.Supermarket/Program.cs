using System;
using System.Collections.Generic;

namespace T6.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                if (command == "Paid")
                {
                    foreach (var person in queue)
                    {
                        Console.WriteLine(person);
                    }
                    queue.Clear();
                }
                else
                {
                    queue.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
