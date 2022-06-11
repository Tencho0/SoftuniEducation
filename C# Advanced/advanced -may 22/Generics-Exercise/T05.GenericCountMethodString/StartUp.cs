namespace T05.GenericCountMethodString
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string cmd = Console.ReadLine();
                list.Add(cmd);
            }
            string comparableLine = Console.ReadLine();
            var box = new Box<string>(list);
            Console.WriteLine(box.CountOfGreaterElements(list, comparableLine));
        }
    }
}
