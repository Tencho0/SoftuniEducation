using System;

namespace T09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
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

                Trainer trainer = new Trainer()
                {
                    Name = trainerName,
                    PokemonCollection = 
                };
                command = Console.ReadLine();
            }
        }
    }
}
