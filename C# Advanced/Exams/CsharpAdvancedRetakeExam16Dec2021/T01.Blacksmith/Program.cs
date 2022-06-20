using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Blacksmith
{
    internal class Program
    {
        static Dictionary<int, string> swords = new Dictionary<int, string>()
        {
            {70 , "Gladius"},
            {80, "Shamshir"},
            {90, "Katana"},
            {110 , "Sabre"},
            {150, "Broadsword"}
        };
        static Dictionary<string, int> collectedSwords = new Dictionary<string, int>()
        {
            {"Gladius",0 },
            {"Shamshir",0},
            {"Katana",0},
            {"Sabre", 0},
            {"Broadsword", 0}
        };
        static void Main(string[] args)
        {
            int[] givenSteel = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] givenCarbon = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Queue<int> steel = new Queue<int>(givenSteel);
            Stack<int> carbon = new Stack<int>(givenCarbon);

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int currSteel = steel.Dequeue();
                int currCarbon = carbon.Peek();
                int sum = currSteel + currCarbon;

                if (swords.ContainsKey(sum))
                {
                    carbon.Pop();
                    string element = swords[sum];
                    collectedSwords[element]++;
                }
                else
                {
                    carbon.Push(carbon.Pop() + 5);
                }

            }
            if (collectedSwords.Values.Sum() > 0)
                Console.WriteLine($"You have forged {collectedSwords.Values.Sum()} swords.");
            else
                Console.WriteLine($"You did not have enough resources to forge a sword.");

            if (steel.Count == 0)
                Console.WriteLine($"Steel left: none");
            else
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");

            if (carbon.Count == 0)
                Console.WriteLine($"Carbon left: none");
            else
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");

            foreach (var sword in collectedSwords.Where(x => x.Value > 0).OrderBy(x => x.Key))
                Console.WriteLine($"{sword.Key}: {sword.Value}");
        }
    }
}
