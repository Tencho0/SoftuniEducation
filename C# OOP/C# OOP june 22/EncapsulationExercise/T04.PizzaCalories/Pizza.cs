using System;
using System.Collections.Generic;
using System.Text;

namespace T04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private string dough;
        private List<Topping> toppings;
        private Pizza()
        {
            Toppings = new List<Topping>();
        }
        public Pizza(string name, string dough)
            : this()
        {
            Name = name;
            Dough = dough;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public string Dough
        {
            get { return dough; }
            private set { dough = value; }
        }
        public List<Topping> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }

    }
}
