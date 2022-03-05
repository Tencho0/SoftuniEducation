using System;
using System.Collections.Generic;
using System.Linq;

namespace T06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondDeck = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (true)
            {
                int firstDeckCount = firstDeck.Count;
                int secondDeckCount = secondDeck.Count;
                if (firstDeckCount == 0 || secondDeckCount == 0)
                {
                    string winner = string.Empty;
                    int sum = 0;
                    if (firstDeckCount == 0)
                    {
                        winner = "Second";
                        sum = secondDeck.Sum();
                    }
                    else
                    {
                        winner = "First";
                        sum = firstDeck.Sum();
                    }
                    Console.WriteLine($"{winner} player wins! Sum: {sum}");
                    break;
                }
                    int firstCard = firstDeck[0];
                    int secondCard = secondDeck[0];
                    if (firstCard > secondCard)
                    {
                        secondDeck.Remove(secondCard);
                        firstDeck.Remove(firstCard);
                        firstDeck.Add(secondCard);
                        firstDeck.Add(firstCard);
                    }
                    else if (firstCard< secondCard)
                    {
                        firstDeck.Remove(firstCard);
                        secondDeck.Remove(secondCard);
                        secondDeck.Add(firstCard);
                        secondDeck.Add(secondCard);
                    }
                    else
                    {
                        firstDeck.Remove(firstCard);
                        secondDeck.Remove(secondCard);
                    }
            }
        }
    }
}
