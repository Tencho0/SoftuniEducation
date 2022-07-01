using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("neshto");
            list.Add("neshto2");
            list.Add("neshto3");
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.Count);
            Console.WriteLine();
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.Count);
            Console.WriteLine();
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.Count);
            Console.WriteLine();
        }
    }
}
