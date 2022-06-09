using System;

namespace T01.GenericBoxofString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string cmd = Console.ReadLine();
                var box = new Box<string>(cmd);
                Console.WriteLine(box);
            }
        }
    }
}
