using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;
        private string name;
        private int capacity;

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public List<Animal> Animals
        {
            get { return animals; }
            private set { animals = value; }
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
        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
                return $"Invalid animal species.";
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
                return $"Invalid animal diet.";
            if (animals.Count >= Capacity)
                return $"The zoo is full.";

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
        public int RemoveAnimals(string species)
        {
            return Animals.RemoveAll(x => x.Species == species);
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.Where(x => x.Diet == diet).ToList();
        }
        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.First(x => x.Weight == weight);
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            return $"There are {Animals.Count(x=> x.Length >= minimumLength && x.Length <= maximumLength)} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
