using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfValues = Console.ReadLine();
            string firstCommand = Console.ReadLine();
            string secondCommand = Console.ReadLine();
            Console.WriteLine(GetMax(typeOfValues, firstCommand, secondCommand));
        }

        private static string GetMax(string typeOfValues, string firstCommand, string secondCommand)
        {
            if (typeOfValues == "int")
            {
                if (int.Parse(firstCommand) > int.Parse(secondCommand))
                {
                    return firstCommand;
                }
                else
                {
                    return secondCommand;
                }
            }
            else if (typeOfValues == "char")
            {
                int firstChar = char.Parse(firstCommand);
                int secondChar = char.Parse(firstCommand);

                if (firstChar > secondChar)
                {
                    return firstCommand;
                }
                else
                {
                    return secondCommand;
                }
            }
            else
            {
                if (firstCommand.CompareTo(secondCommand) > 0)
                {
                    return firstCommand;
                }
                else
                {
                    return secondCommand;
                }
            }
        }
    }
}
