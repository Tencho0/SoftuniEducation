using System;

namespace Methods___examples___sept_2021
{
    class Program
    {
        static void SayHello(string name)
        {

            Console.WriteLine($"Hallo {name}");
        }

        static void PrintSum(int a, int b)
        {
            Console.WriteLine(a+b);
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b= int.Parse(Console.ReadLine());
            PrintSum(a, b);
            SayHello("Djordjano");
            SayHello("kirchu");
            SayHello(Console.ReadLine());
        }
    }
}
