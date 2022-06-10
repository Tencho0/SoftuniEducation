using System;

namespace T03.GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>
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
