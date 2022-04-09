using System;

namespace T02.GenericBoxofInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> inputBox = new Box<int>(input);
                Console.WriteLine($"{inputBox.ToString()}");
            }
        }
    }
}
