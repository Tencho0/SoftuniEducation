using System;

namespace T01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string travelStops = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Travel")
            {
                string[] givenCmd = command.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                if (action == "Add Stop")
                {
                    int index = int.Parse(givenCmd[1]);
                    string newString = givenCmd[2];
                    if (IsIndexValid(travelStops, index))
                    {
                        travelStops = travelStops.Insert(index, newString);
                    }
                }
                else if (action == "Remove Stop")
                {
                    int startIndex = int.Parse(givenCmd[1]);
                    int endIndex = int.Parse(givenCmd[2]);
                    if (IsIndexValid(travelStops, startIndex) && IsIndexValid(travelStops, endIndex))
                    {
                        travelStops = travelStops.Remove(startIndex, endIndex - startIndex + 1);
                    }
                }
                else if (action == "Switch")
                {
                    string oldString = givenCmd[1];
                    string newString = givenCmd[2];
                    if (travelStops.Contains(oldString))
                    {
                        travelStops = travelStops.Replace(oldString, newString);
                    }
                }
                Console.WriteLine(travelStops);
                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {travelStops}");
        }

        private static bool IsIndexValid(string travelStops, int index)
        {
            return travelStops.Length > index && index >= 0;
        }
    }
}
