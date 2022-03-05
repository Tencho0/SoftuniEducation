using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, int> result = new Dictionary<string, int>();
            while (command != "stop")
            {
                int currQuantity = int.Parse(Console.ReadLine());
                if (!(result.ContainsKey(command)))
                {
                    result.Add(command, currQuantity);
                }
                else
                {
                    result[command] += currQuantity;
                }
                command = Console.ReadLine();
            }
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
