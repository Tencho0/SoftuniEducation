using System;

namespace T02.GenericBoxofInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int cmd = int.Parse(Console.ReadLine());
                var box = new Box<int>(cmd);
                Console.WriteLine(box);
            }
        }
    }
}
