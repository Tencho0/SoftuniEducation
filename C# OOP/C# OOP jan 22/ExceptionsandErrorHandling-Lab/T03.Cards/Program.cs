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
}
