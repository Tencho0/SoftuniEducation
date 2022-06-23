using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private Dictionary<string, Pet> data;
        private int capacity;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            Data = new Dictionary<string, Pet>();
        }

        public int Count => Data.Count;
        public Dictionary<string, Pet> Data
        {
            get { return data; }
            set { data = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public void Add(Pet pet)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(pet.Name, pet);
            }
        }
        public bool Remove(string name)
        {
            if (Data.ContainsKey(name))
            {
                Data.Remove(name);
                return true;
            }
            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            if (Data.ContainsKey(name) && Data[name].Owner == owner)
            {
                return Data[name];
            }
            return null;
        }
        public Pet GetOldestPet()
        {
            int max = Data.Values.Max(x => x.Age);
            return Data.Values.First(x => x.Age >= max);
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The clinic has the following patients:");
            foreach (var (name, pet)in Data)
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            return sb.ToString().TrimEnd();
        }
    }
}
