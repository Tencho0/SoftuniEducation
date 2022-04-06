using System;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Ivan";
            Action<string> printName = x => Console.WriteLine(x);
            printName(name);
            PrintName(name);

            int num = 5;
            Predicate<int> isEven = x => x % 2 == 0;
            bool isNumEven = isEven(num);
            bool isNumEvenMethod = IsEven(num);

            int x = 3;
            int y = 7;
            Func<int, int, int> sum = (x, y) => x + y;
            int result = sum(x, y);
            int resultMethod = Sum(x, y);

        }
        public static int Sum(int x, int y)
        {
            return x + y;
        }
        public static void PrintName(string name)
        {
            Console.WriteLine(name);
        }
        public static bool IsEven(int n)
        {
            return n % 2 == 0;
        }
    }
}
