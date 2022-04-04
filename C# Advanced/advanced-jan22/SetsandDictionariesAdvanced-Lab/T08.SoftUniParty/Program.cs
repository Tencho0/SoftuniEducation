using System;
using System.Collections.Generic;

namespace T08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuessts = new HashSet<string>();
            HashSet<string> regularGuessts = new HashSet<string>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command == "PARTY")
                {
                    command = Console.ReadLine();
                    while (command != "END")
                    {
                        if (char.IsDigit(command[0]))
                        {
                            vipGuessts.Remove(command);
                        }
                        else
                        {
                            regularGuessts.Remove(command);
                        }
                        command = Console.ReadLine();
                    }
                    break;
                }
                else
                {
                    if (char.IsDigit(command[0]))
                    {
                        vipGuessts.Add(command);
                    }
                    else
                    {
                        regularGuessts.Add(command);
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(regularGuessts.Count + vipGuessts.Count);
            foreach (var item in vipGuessts)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regularGuessts)
            {
                Console.WriteLine(item);
            }
        }
    }
}
