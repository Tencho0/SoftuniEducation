using System;

namespace _07._Repeat_String___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            string repeatedString = RepeatedCommand(Console.ReadLine(), int.Parse(Console.ReadLine()));
            Console.WriteLine(repeatedString);
        }
        static string RepeatedCommand(string value, int times)
        {
            string result = "";
            for (int i = 0; i < times; i++)
            {
                result += value;
            }
            return result;
        }
    }
}
