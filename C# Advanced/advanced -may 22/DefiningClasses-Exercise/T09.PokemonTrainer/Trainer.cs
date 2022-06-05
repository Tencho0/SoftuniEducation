using System;
using System.Collections.Generic;
using System.Text;

namespace T09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer()
        {
            PokemonCollection = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> PokemonCollection { get; set; }
    }
}
