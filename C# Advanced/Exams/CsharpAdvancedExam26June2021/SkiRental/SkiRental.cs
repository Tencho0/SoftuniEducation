using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        private string name;
        private int capacity;
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Ski>();
        }
        public int Count => Data.Count;
        public List<Ski> Data
        {
            get { return data; }
            set { data = value; }
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
        public void Add(Ski ski)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
           // return Data.Remove(Data.First(x => x.Manufacturer == manufacturer && x.Model == model));
            if (Data.Any(x=> x.Manufacturer == manufacturer && x.Model == model))
            {
                Data.Remove(Data.First(x => x.Manufacturer == manufacturer && x.Model == model));
                return true;    
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            if (Data.Count == 0)
                return null;
            int max = Data.Max(x => x.Year);
            return Data.First(x => x.Year == max);
        }
        public Ski GetSki(string manufacturer, string model)
        {
            if (Data.Any(x => x.Manufacturer == manufacturer && x.Model == model))
                return Data.First(x => x.Manufacturer == manufacturer && x.Model == model);
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {this.Name}:");

            foreach (var item in Data)
                sb.AppendLine(item.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
