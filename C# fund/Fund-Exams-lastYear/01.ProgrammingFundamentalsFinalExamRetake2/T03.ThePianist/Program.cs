using System;
using System.Collections.Generic;

namespace T03.ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);
                string pieceName = input[0];
                string composer = input[1];
                string key = input[2];
                Piece piece = new Piece()
                {
                    Composer = composer,
                    Key = key
                };
                pieces[pieceName] = piece;
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
                    if (pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        Piece newPiece = new Piece()
                        {
                            Composer = composer,
                            Key = key
                        };
                        pieces[piece] = newPiece;
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (action == "Remove")
                {
                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
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
                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece].Key = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
    }
    class Piece
    {
        public string Composer { get; set; }
        public string Key { get; set; }
    }
}
