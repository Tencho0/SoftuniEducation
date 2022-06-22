using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private string name;
        private int capacity;
        private Dictionary<string, Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new Dictionary<string, Racer>();
        }
        public int Count => Data.Count;
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

        public Dictionary<string, Racer> Data
        {
            get { return data; }
            set { data = value; }
        }
        public void Add(Racer Racer)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(Racer.Name, Racer);
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
        public Racer GetOldestRacer()
        {
            int max = Data.Values.Max(x => x.Age);
            return Data.Values.First(x => x.Age >= max);
        }
        public Racer GetRacer(string name)
        {
            return Data[name];
        }
        public Racer GetFastestRacer()
        {
            int max = Data.Values.Max(x => x.Car.Speed);
            return Data.Values.First(x => x.Car.Speed >= max);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var item in Data)
                sb.AppendLine(item.Value.ToString());
            return sb.ToString().TrimEnd();
        }
    }
}
