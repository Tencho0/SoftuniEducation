using System;

namespace T01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string command =Console.ReadLine();
            while (command != "Travel")
            {
                string[] givenCmd = command.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                if (action == "Add Stop")
                {
                    int index = int.Parse(givenCmd[1]);
                    string newString = givenCmd[2];
                    if (IsIndexValid(stops, index))
                    {
                        stops = stops.Insert(index, newString);
                    }
                }
                else if (action == "Remove Stop")
                {
                    int startIndex = int.Parse(givenCmd[1]);
                    int endIndex = int.Parse(givenCmd[2]);
                    if (IsIndexValid(stops, startIndex) && IsIndexValid(stops, endIndex))
                    {
                        stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                    }
                }
                else if (action== "Switch")
                {
                    string oldString = givenCmd[1];
                    string newString = givenCmd[2];
                    if (stops.Contains(oldString))
                    {
                        stops = stops.Replace(oldString, newString);
                    }
                }
                Console.WriteLine(stops);
                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }

        private static bool IsIndexValid(string stops, int index)
        {
            return index >= 0 && index < stops.Length;
        }
    }
}
