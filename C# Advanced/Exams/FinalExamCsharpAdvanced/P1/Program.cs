using System;
using System.Collections.Generic;
using System.Linq;


namespace P1
{
    public class Program
    {
        static Dictionary<int, string> tiles = new Dictionary<int, string>()
        {
            {40, "Sink" },
            {50 ,"Oven" },
            {60 ,"Countertop" },
            {70 ,"Wall" }
        };
        static Dictionary<string, int> tilesAmounts = new Dictionary<string, int>()
        {
            {"Sink" ,0},
            {"Oven" ,0},
            {"Countertop",0 },
            {"Wall" ,0},
            {"Floor" ,0}
        };
        static void Main(string[] args)
        {
            int[] givenWhiteTiles = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            int[] givenGreyTiles = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> whiteTiles = new Stack<int>(givenWhiteTiles);
            Queue<int> greyTiles = new Queue<int>(givenGreyTiles);

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int whiteArea = whiteTiles.Peek();
                int greyArea = greyTiles.Peek();
                int sum = whiteArea + greyArea;

                if (whiteArea == greyArea)
                {
                    if (tiles.ContainsKey(sum))
                    {
                        whiteTiles.Pop();
                        greyTiles.Dequeue();
                        string currFood = tiles[sum];
                        tilesAmounts[currFood]++;
                    }
                    else
                    {
                        tilesAmounts["Floor"]++;
                        whiteTiles.Pop();
                        greyTiles.Dequeue();
                    }
                }
                else
                {
                    whiteTiles.Push(whiteTiles.Pop() / 2);
                    greyTiles.Enqueue(greyTiles.Dequeue());
                }
            }
            if (whiteTiles.Count == 0)
                Console.WriteLine($"White tiles left: none");
            else
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");

            if (greyTiles.Count == 0)
                Console.WriteLine($"Grey tiles left: none");
            else
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");

            foreach (var (tile, amount) in tilesAmounts.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                Console.WriteLine($"{tile}: {amount}");
            //  PrintResult();
        }

      //  private static void PrintResult()
      //  {
      //      if (whiteTiles.Count == 0)
      //          Console.WriteLine($"White tiles left: none");
      //      else
      //          Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
      //
      //      if (greyTiles.Count == 0)
      //          Console.WriteLine($"Grey tiles left: none");
      //      else
      //          Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
      //
      //      foreach (var (tile, amount) in tilesAmounts.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
      //          Console.WriteLine($"{tile}: {amount}");
      //  }
    }
}
