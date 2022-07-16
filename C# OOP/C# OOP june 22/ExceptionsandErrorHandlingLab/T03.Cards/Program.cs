using System;
using System.Collections.Generic;

namespace T03.Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> cars = new List<Card>();

            foreach (var currPair in array)
            {
                string[] currPairCmd = currPair
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string face = currPairCmd[0];
                string suit = currPairCmd[1];

                try
                {
                    Card card = new Card(face, suit);
                    cars.Add(card);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid card!");
                }
            }

            Console.WriteLine(string.Join(" ", cars));
        }
    }
    public class Card
    {
        private static HashSet<string> faces = new HashSet<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private string face;
        private string suit;
        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Face
        {
            get { return face; }
            set
            {
                if (!faces.Contains(value))
                {
                    throw new ArgumentException();
                }
                face = value;
            }
        }
        public string Suit
        {
            get { return suit; }
            set
            {
                if (value == "S")
                {
                    suit = "\u2660";
                }
                else if (value == "H")
                {
                    suit = "\u2665";
                }
                else if (value == "D")
                {
                    suit = "\u2666";
                }
                else if (value == "C")
                {
                    suit = "\u2663";
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }
    }
}
