using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private Dictionary<string, Ingredient> ingredients;
        private string name;
        private int capacity;
        private int maxAlcoholLevel;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new Dictionary<string, Ingredient>();
        }
        public int CurrentAlcoholLevel => this.Ingredients.Sum(x=> x.Value.Alcohol);
        public Dictionary<string, Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public int MaxAlcoholLevel
        {
            get { return maxAlcoholLevel; }
            set { maxAlcoholLevel = value; }
        }
        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.ContainsKey(ingredient.Name) && Ingredients.Count < Capacity && ingredient.Alcohol <= MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient.Name, ingredient);
            }
        }
        public bool Remove(string name)
        {
            if (Ingredients.ContainsKey(name))
            {
                Ingredients.Remove(name);
                return true;
            }
            return false;
        }
        public Ingredient FindIngredient(string name)
        {
            if (Ingredients.ContainsKey(name))
            {
                return Ingredients[name];
            }
            return null;
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            if (Ingredients.Count > 0)
            {
                int max = Ingredients.Values.Max(x => x.Alcohol);
                return Ingredients.Values.First(x => x.Alcohol >= max);
            }
            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var (ingridientName, ingridient) in Ingredients)
                sb.AppendLine(ingridient.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
