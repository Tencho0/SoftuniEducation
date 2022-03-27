using System;
using System.Collections.Generic;
using System.Linq;

namespace T06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] givenSongs = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(givenSongs);
            while (songs.Count > 0)
            {
                List<string> givenCmd = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                string action = givenCmd[0];
                givenCmd.RemoveAt(0);
                if (action == "Play")
                {
                    songs.Dequeue();
                }
                else if (action == "Add")
                {
                    string newSong = string.Join(" ", givenCmd);
                    if (songs.Contains(newSong))
                    {
                        Console.WriteLine($"{newSong} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(newSong);
                    }
                }
                else if (action == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine($"No more songs!");
        }
    }
}
