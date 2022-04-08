using System;
using System.Collections.Generic;
using System.Linq;

namespace T09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string command = Console.ReadLine();
            while (command != "Tournament")
            {
                string[] givenData = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = givenData[0];
                string pokemonName = givenData[1];
                string pokemonElement = givenData[2];
                int pokemonHealth = int.Parse(givenData[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainers[trainerName] = trainer;
                }
                trainers[trainerName].Pokemons.Add(pokemon);
                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while (command != "End")
            {
                CalculateBadges(trainers, command);
                command = Console.ReadLine();
            }
            foreach (var trainer in trainers.OrderByDescending(x => x.Value.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.NumberOfBadges} {trainer.Value.Pokemons.Count}");
            }
        }
        private static void CalculateBadges(Dictionary<string, Trainer> trainers, string element)
        {
            foreach (var currTrainer in trainers)
            {
                //int firePokemons = currTrainer.Value.Pokemons
                //   .Where(x => x.Element == $"{element}").Count();
                //if (firePokemons > 0)
                //{
                //    currTrainer.Value.NumberOfBadges++;
                //}
                var isAny = currTrainer.Value.Pokemons.Any(x => x.Element == $"{element}");
                if (isAny)
                {
                    currTrainer.Value.NumberOfBadges++;
                }
                else
                {
                    //currTrainer.Value.Pokemons.Select(x => x.Health -=10);
                    currTrainer.Value.Pokemons.ForEach(x => x.Health -= 10);
                    List<Pokemon> currPokemons = currTrainer.Value.Pokemons.Where(x=> x.Health <= 0).ToList();
                    currPokemons.ForEach(x => currTrainer.Value.Pokemons.Remove(x));
                }
            }
        }
    }
}
