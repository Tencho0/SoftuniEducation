using System;
using System.Text;

namespace T01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine(); 
          //  StringBuilder result = new StringBuilder(text);
            string command = Console.ReadLine();
            while (command != "Done")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (givenCmd[0] == "TakeOdd")
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 1; i < text.Length; i+=2)
                    {
                      //  sb.Append(result[i]);
                        sb.Append(text[i]);
                    }
                    //  result = sb;
                    //  Console.WriteLine(result.ToString().Trim());
                    text = sb.ToString();
                    Console.WriteLine(text);
                }
                else if (givenCmd[0] == "Cut")
                {
                    int index = int.Parse(givenCmd[1]);
                    int length = int.Parse(givenCmd[2]);
                    //result.Remove(index, length);
                    //Console.WriteLine(result.ToString().Trim());
                    text = text.Remove(index, length);
                    Console.WriteLine(text);
                }
                else if (givenCmd[0]== "Substitute")
                {
                    string substring = givenCmd[1];
                    string substitute = givenCmd[2];
                    //if (result.ToString().IndexOf(substring) != -1)
                    //{
                    //    result.Replace(substring, substitute);
                    //    Console.WriteLine(result.ToString().Trim());
                    //}
                    if (text.IndexOf(substring) != -1)
                    {
                        text = text.Replace(substring, substitute);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine($"Nothing to replace!");
                    }
                }
                command = Console.ReadLine();
            }
           // Console.WriteLine($"Your password is: {result.ToString().Trim()}");
            Console.WriteLine($"Your password is: {text}");
        }
    }
}
