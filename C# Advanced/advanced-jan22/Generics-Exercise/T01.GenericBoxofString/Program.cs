using System;

namespace T01.GenericBoxofString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Box<string> inputBox = new Box<string>(input);
                Console.WriteLine($"{inputBox.ToString()}");
            }
        }
    }
}
