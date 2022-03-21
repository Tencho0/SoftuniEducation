using System;
using System.Text;

namespace T01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            StringBuilder sb = new StringBuilder(stops);

            string command = Console.ReadLine();
            while (command != "Travel")
            {
                string[] givemCmd = command.Split(':');
                if (givemCmd[0] == "Add Stop")
                {
                    int index = int.Parse(givemCmd[1]);
                    if (index >= 0 && index < sb.Length)
                    {
                    sb.Insert(index, givemCmd[2]);
                    }
                }
                else if (givemCmd[0]== "Remove Stop")
                {
                    int startIndex = int.Parse(givemCmd[1]);
                    int endIndex = int.Parse(givemCmd[2]);
                    if (startIndex >= 0 && startIndex < sb.Length && endIndex>= 0 && endIndex< sb.Length)
                    {
                        sb.Remove(startIndex, endIndex - startIndex +1);
                    }
                }
                else if (givemCmd[0] == "Switch")
                {
                    string oldString = givemCmd[1];
                    string newString = givemCmd[2];
                    int index = sb.ToString().IndexOf(oldString);
                    if (index != -1)
                    {
                        sb.Replace(oldString, newString);
                    }
                }
                Console.WriteLine($"{sb.ToString()}");
                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {sb.ToString()}");
        }
    }
}
