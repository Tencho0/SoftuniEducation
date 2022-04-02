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
                string[] pieceData = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string pieceName = pieceData[0];
                string composer = pieceData[1];
                string key = pieceData[2];
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
                string[] givenCmd = command.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                string pieceName = givenCmd[1];
                if (action == "Add")
                {
                    string composer = givenCmd[2];
                    string key = givenCmd[3];
                    if (pieces.ContainsKey(pieceName))
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                    }
                    else
                    {
                        Piece piece = new Piece()
                        {
                            Composer = composer,
                            Key = key
                        };
                        pieces[pieceName] = piece;
                        Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                    }
                }
                else if (action == "Remove")
                {
                    if (pieces.ContainsKey(pieceName))
                    {
                        pieces.Remove(pieceName);
                        Console.WriteLine($"Successfully removed {pieceName}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
                else if (action == "ChangeKey")
                {
                    string newKey = givenCmd[2];
                    if (pieces.ContainsKey(pieceName))
                    {
                        pieces[pieceName].Key = newKey;
                        Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
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
