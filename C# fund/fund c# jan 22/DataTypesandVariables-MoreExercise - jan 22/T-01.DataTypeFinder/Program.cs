using System;

namespace T_01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            double floatingPoint;
            char character;
            bool boolean;
            string stringType;

            string givenCommand = Console.ReadLine();
            while (givenCommand != "END")
            {
                string currType = string.Empty;
                if (int.TryParse(givenCommand, out number))
                {
                    currType = "integer";
                }
                else if (double.TryParse(givenCommand, out floatingPoint))
                {
                    currType = "floating point";
                }
                else if (char.TryParse(givenCommand, out character))
                {
                    currType = "character";
                }
                else if (bool.TryParse(givenCommand, out boolean))
                {
                    currType = "boolean";
                }
                else
                {
                    currType = "string";
                }
                Console.WriteLine($"{givenCommand} is {currType} type");
                givenCommand = Console.ReadLine();
            }
        }
    }
}
