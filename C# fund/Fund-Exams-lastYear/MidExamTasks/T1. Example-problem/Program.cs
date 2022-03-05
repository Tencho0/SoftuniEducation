using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T1._Example_problem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string givenString = Console.ReadLine();
            List<string> givenInputAsChar = new List<string>();
            string command = Console.ReadLine();
            while (command != "Done")
            {
                string[] givenCmd = command.Split();
                string currCmd = givenCmd[0];
                if (currCmd == "TakeOdd")
                {
                    for (int i = 1; i < givenString.Length; i+=2)
                    {
                        givenInputAsChar.Add(givenString[i].ToString());
                    }
                    Console.WriteLine(string.Join("", givenInputAsChar));
                }
                else if (currCmd == "Cut")
                {
                    int index = int.Parse(givenCmd[1]);
                    int length = int.Parse(givenCmd[2]);
                    for (int i = 0; i < length; i++)
                    {
                        givenInputAsChar.RemoveAt(index);
                    }
                    Console.WriteLine(string.Join("",givenInputAsChar));
                }
                else if (currCmd == "Substitute")
                {
                    string[] givenFirstCmd = givenCmd[1].Split();
                    string firstCmd = givenFirstCmd[0];
                    string secondCmd = givenCmd[2];
                    if (givenInputAsChar.Contains(firstCmd))
                    {
                        while (givenInputAsChar.Contains(firstCmd))
                        {
                            int currIndex = givenInputAsChar.IndexOf(firstCmd);
                            givenInputAsChar[currIndex] = secondCmd;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                    Console.WriteLine(string.Join("",givenInputAsChar));
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {string.Join("",givenInputAsChar)}");
        }
    }
}
