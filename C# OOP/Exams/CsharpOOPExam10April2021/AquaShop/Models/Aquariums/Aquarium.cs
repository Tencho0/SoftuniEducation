namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decorations = new List<IDecoration>();
            fish = new List<IFish>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);

                name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            private set
            {
                capacity = value;
            }
        }

        public int Comfort => Decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => decorations;

        public ICollection<IFish> Fish => fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count >= this.Capacity)
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);

            this.fish.Add(fish);
        }

        public void Feed()
          => this.fish.ToList().ForEach(x => x.Eat());
        // {
        //     foreach (var currFish in this.Fish)
        //         currFish.Eat();
        // }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (this.Fish.Count == 0)
                sb.AppendLine("Fish: none");
            else
                sb.AppendLine($"Fish: {string.Join(", ", this.Fish.Select(x => x.Name))}");
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
