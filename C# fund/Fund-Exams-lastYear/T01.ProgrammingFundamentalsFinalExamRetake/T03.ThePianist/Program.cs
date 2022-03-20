using System;
using System.Collections.Generic;

namespace T03.ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Song> songs = new Dictionary<string, Song>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenCmd = Console.ReadLine().Split('|');
                string piece = givenCmd[0];
                string composer = givenCmd[1];
                string key = givenCmd[2];
                Song song = new Song(composer, key);
                songs[piece] = song;
            }
            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] givenCmd = command.Split('|');
                string action = givenCmd[0];
                string piece = givenCmd[1];
                if (action == "Add")
                {
                    string composer = givenCmd[2];
                    string key = givenCmd[3];
                    if (songs.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        Song song = new Song(composer, key);
                        songs[piece] = song;
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (action == "Remove")
                {
                    if (songs.ContainsKey(piece))
                    {
                        songs.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (action == "ChangeKey")
                {
                    string newKey = givenCmd[2];
                    if (songs.ContainsKey(piece))
                    {
                        songs[piece].Key = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var song in songs)
            {
                Console.WriteLine($"{song.Key} -> Composer: {song.Value.Composer}, Key: {song.Value.Key}");
            }
        }
    }
    class Song
    {
        public Song(string composer, string key)
        {
            this.Composer = composer;
            this.Key = key;
        }
        public string Composer { get; set; }
        public string Key { get; set; }

    }
}
