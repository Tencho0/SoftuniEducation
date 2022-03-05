using System;

namespace _09._Greater_of_Two_Values___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            if (type == "string")
            {
                Console.WriteLine(GetMax(a, b));
            }
            else if (type == "int")
            {
                Console.WriteLine(GetMax(int.Parse(a), int.Parse(b)));
            }
            else
            {
                Console.WriteLine(GetMax(char.Parse(a), char.Parse(b))); 
            }
        }
        static int GetMax(int a, int b)
        {
            if (a < b)
            {
                return b;
            }
            else
            {
                return a;
            }
        }
        static char GetMax(char a, char b)
        {
            if (a < b)
            {
                return b;
            }
            else
            {
                return a;
            }
        }
        static string GetMax(string a, string b)
        {
            if (a.CompareTo(b) > 0)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}
