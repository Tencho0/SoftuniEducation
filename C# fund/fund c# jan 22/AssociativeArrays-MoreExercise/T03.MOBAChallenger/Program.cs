using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.MOBAChallenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> players =
                new Dictionary<string, Dictionary<string, int>>();

            string command = Console.ReadLine();
            while (command != "Season end")
            {
                string[] givenCmd = command.Split();
                string currOperator = givenCmd[1];
                if (currOperator == "->")
                {
                    AddPlayer(players, givenCmd);
                }
                else if (currOperator == "vs")
                {
                    PlayersFight(players, givenCmd);
                }
                command = Console.ReadLine();
            }
            PrintResult(players);
        }
        public static void PrintResult(Dictionary<string, Dictionary<string, int>> players)
        {
            foreach (var item in players.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()} skill");
                foreach (var possition in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"- {possition.Key} <::> {possition.Value}");
                }
            }
        }
        public static void PlayersFight(Dictionary<string, Dictionary<string, int>> players, string[] givenCmd)
        {
            string name = givenCmd[0];
            string secondPlayer = givenCmd[2];
            bool isCommonPossition = false;
            if (players.ContainsKey(name) && players.ContainsKey(secondPlayer))
            {
                foreach (var firstPossition in players[name])
                {
                    foreach (var secondPossition in players[secondPlayer])
                    {
                        if (firstPossition.Key == secondPossition.Key)
                        {
                            isCommonPossition = true;
                            if (firstPossition.Value > secondPossition.Value)
                            {
                                players.Remove(secondPlayer);
                            }
                            else if (firstPossition.Value < secondPossition.Value)
                            {
                                players.Remove(name);
                            }
                            break;
                        }
                    }
                    if (isCommonPossition)
                    {
                        break;
                    }
                }
            }
        }
        public static void AddPlayer(Dictionary<string, Dictionary<string, int>> players, string[] givenCmd)
        {
            string name = givenCmd[0];
            string possition = givenCmd[2];
            int skill = int.Parse(givenCmd[4]);
            if (!players.ContainsKey(name))
            {
                players[name] = new Dictionary<string, int>();
                players[name][possition] = skill;
            }
            else
            {
                if (players[name].ContainsKey(possition))
                {
                    if (players[name][possition] < skill)
                    {
                        players[name][possition] = skill;
                    }
                }
                else
                {
                    players[name][possition] = skill;
                }
            }
        }
    }
}
