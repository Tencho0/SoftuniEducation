using System;
using System.Collections.Generic;

namespace T01.AdvertisementMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> phrases = new List<string>()
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };
            List<string> events = new List<string>()
            {"Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };
            List<string> authors = new List<string>()
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };
            List<string> cities = new List<string>()
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                string phrase = phrases[random.Next(phrases.Count -1)];
                string currEvent = events[random.Next(events.Count -1 )];
                string author = authors[random.Next(authors.Count -1)];
                string city = cities[random.Next(cities.Count -1)];
                Console.WriteLine($"{phrase} {currEvent} {author} – {city}.");
            }
        }
    }
}
