using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Bombs
{
    internal class Program
    {
        static Dictionary<int, string> bombsMaterials = new Dictionary<int, string>()
        {
            {40, "Datura Bombs"},
            {60,"Cherry Bombs"},
            {120, "Smoke Decoy Bombs"}
        };
        static Dictionary<string, int> bombs = new Dictionary<string, int>()
        {
            {"Cherry Bombs",0},
            {"Datura Bombs", 0 },
            {"Smoke Decoy Bombs", 0}
        };
        static void Main(string[] args)
        {
            int[] givenEffects = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] givenCasings = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> effects = new Queue<int>(givenEffects);
            Stack<int> casings = new Stack<int>(givenCasings);

            while (effects.Count> 0 && casings.Count > 0)
            {
                int currEffect = effects.Peek();
                int currCasing = casings.Peek();
                int sum = currEffect + currCasing;

                if (bombsMaterials.ContainsKey(sum))
                {
                    effects.Dequeue();
                    casings.Pop();
                    string bombMaterial = bombsMaterials[sum];
                    bombs[bombMaterial]++;
                }
                else
                    casings.Push(casings.Pop() - 5);

                if (!bombs.Values.Any(x=> x < 3)) break;
            }
            PrintResult(effects, casings);
        }

        private static void PrintResult(Queue<int> effects, Stack<int> casings)
        {
            if (bombs.Values.Any(x => x < 3))
                Console.WriteLine($"You don't have enough materials to fill the bomb pouch.");
            else
                Console.WriteLine($"Bene! You have successfully filled the bomb pouch!");
            if (effects.Count > 0)
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            else
                Console.WriteLine($"Bomb Effects: empty");
            if (casings.Count == 0)
                Console.WriteLine($"Bomb Casings: empty");
            else
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");

            foreach (var (bombName, count) in bombs)
                Console.WriteLine($"{bombName}: {count}");
        }
    }
}
