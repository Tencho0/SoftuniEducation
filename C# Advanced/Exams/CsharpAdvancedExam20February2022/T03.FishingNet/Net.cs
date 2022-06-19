using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private readonly ICollection<Fish> fish;
        private string material;
        private int capacity;

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            fish = new List<Fish>();
        }
        public int Count => fish.Count;
        public IReadOnlyCollection<Fish> Fish => (IReadOnlyCollection<Fish>)this.fish;
        public string Material
        {
            get { return material; }
            set { material = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
                return $"Invalid fish.";
            if (this.fish.Count + 1 > Capacity)
                return $"Fishing net is full.";

            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            var fishToRemove = fish.FirstOrDefault(x => x.Weight == weight);
            if (fishToRemove != null)
                return this.fish.Remove(fishToRemove);
            return false;
        }
        public Fish GetFish(string fishType)
        {
            return this.fish.First(x => x.FishType == fishType);
        }
        public Fish GetBiggestFish()
        {
            return this.fish.First(x => x.Length == fish.Max(y => y.Length));
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {material}:");
            foreach (var item in fish.OrderByDescending(x => x.Length))
                sb.AppendLine(item.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
