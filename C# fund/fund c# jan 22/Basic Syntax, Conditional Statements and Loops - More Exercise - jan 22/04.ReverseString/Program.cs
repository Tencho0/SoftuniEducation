using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string reversed = string.Empty;
            for (int i = 0; i < command.Length; i++)
            {
                reversed += command[command.Length - 1 - i];
            }
            Console.WriteLine(reversed);
        }
    }
}
