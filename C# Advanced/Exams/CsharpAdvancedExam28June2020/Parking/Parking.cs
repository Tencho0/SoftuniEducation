using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        private string type;
        private int capacity;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Data = new List<Car>();
        }
        public int Count => Data.Count;
        public List<Car> Data
        {
            get { return data; }
            set { data = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public void Add(Car car)
        {
            if (Data.Count < Capacity)
                Data.Add(car);
        }
        public bool Remove(string manufacturer, string model)
        {
            if (Data.Any(x => x.Manufacturer == manufacturer && x.Model == model))
            {
                Data.Remove(Data.First(x => x.Manufacturer == manufacturer && x.Model == model));
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            if (Data.Count == 0)
                return null;
            int maz = Data.Max(x => x.Year);
            return Data.First(x=> x.Year >= maz);
        }
        public Car GetCar(string manufacturer, string model)
        {
            if (Data.Any(x => x.Manufacturer == manufacturer && x.Model == model))
                return Data.First(x => x.Manufacturer == manufacturer && x.Model == model);
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var item in Data)
                sb.AppendLine(item.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
