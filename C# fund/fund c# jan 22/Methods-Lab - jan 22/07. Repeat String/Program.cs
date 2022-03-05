using System;
using System.Text;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int reps = int.Parse(Console.ReadLine());
            Console.WriteLine(ReturnedString(command, reps));
        }

        private static string ReturnedString(string command, int reps)
        {
           // string newWord = string.Empty;
            StringBuilder strinBuilder = new StringBuilder();
            for (int i = 0; i < reps; i++)
            {
                strinBuilder.Append(command);
                //newWord += command;
            }
            return strinBuilder.ToString();
            //return newWord;
        }
    }
}
