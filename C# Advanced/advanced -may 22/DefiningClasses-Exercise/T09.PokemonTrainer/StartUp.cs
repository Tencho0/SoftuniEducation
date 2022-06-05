namespace T09.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            string command = Console.ReadLine();
            while (command != "Tournament")
            {
                string[] givenData = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = givenData[0];
                string pokemonName = givenData[1];
                string pokemonElement = givenData[2];
                int pokemonHealth = int.Parse(givenData[3]);

                Pokemon pokemon = new Pokemon()
                {
                    Name = pokemonName,
                    Element = pokemonElement,
                    Health = pokemonHealth
                };

                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer()
                    {
                        Name = trainerName,
                    };
                    trainers[trainerName] = trainer;
                }
                trainers[trainerName].PokemonCollection.Add(pokemon);

                command = Console.ReadLine();
            }

            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.PokemonCollection.Any(x => x.Element == cmd))
                        trainer.Value.NumberOfBadges++;
                    else
                    {
                        trainer.Value.PokemonCollection.ForEach(x => x.Health -= 10);
                        List<Pokemon> currPokemons = trainer.Value.PokemonCollection.Where(x => x.Health <= 0).ToList();
                        currPokemons.ForEach(x => trainer.Value.PokemonCollection.Remove(x)); trainer.Value.PokemonCollection.RemoveAll(x => x.Health < 0);
                    }
                }

                cmd = Console.ReadLine();
            }
            foreach (var trainer in trainers.OrderByDescending(x => x.Value.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Value.Name} {trainer.Value.NumberOfBadges} {trainer.Value.PokemonCollection.Count}");
            }
        }
    }
}
