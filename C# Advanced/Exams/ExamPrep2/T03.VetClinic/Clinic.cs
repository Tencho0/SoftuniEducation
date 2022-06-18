using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private Dictionary<string, Pet> data;
        public Clinic(int capacity)
        {
            Capacity = capacity;
            Data = new Dictionary<string, Pet>();
        }

        public int Capacity { get; set; }
        public int Count => Data.Count;
        public Dictionary<string, Pet> Data
        {
            get { return data; }
            private set { data = value; }
        }
        public void Add(Pet pet)
        {
            if (Data.Count < Capacity)
                Data[pet.Name] = pet;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var (petName, pet) in Data)
                sb.AppendLine($"Pet {petName} with owner: {pet.Owner}");
            return sb.ToString().TrimEnd();
        }

        public bool Remove(string name) => Data.Remove(name);
        public Pet GetPet(string name, string owner)
            => Data.Values.First(x => x.Name == name && x.Owner == owner);
        public Pet GetOldestPet()
            => Data.Values.First(x => x.Age == Data.Values.Max(y => y.Age));
    }
}
