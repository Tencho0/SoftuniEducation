using System;
using System.Collections.Generic;
using System.Text;

namespace T09.PokemonTrainer
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Element
        {
            get { return element; }
            set { element = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

    }
}
