using System;
using System.Collections.Generic;

namespace T06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> songs = new Queue<string>(arr);

            while (songs.Count > 0)
            {
                string givenCommand = Console.ReadLine();
                if (givenCommand == "Play")
                {
                    songs.Dequeue();
                }
                else if (givenCommand.StartsWith("Add"))
                {
                    string song = givenCommand.Substring(4);
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                        continue;
                    }
                    songs.Enqueue(song);
                }
                else if (givenCommand == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine($"No more songs!");
        }
    }
}
