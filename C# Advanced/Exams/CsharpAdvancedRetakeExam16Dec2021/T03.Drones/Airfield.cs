using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private string name;
        private int capacity;
        private double landingStrip;
        private Dictionary<string, Drone> drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new Dictionary<string, Drone>();
        }
        public int Count => Drones.Count;
        public Dictionary<string, Drone> Drones
        {
            get { return drones; }
            set { drones = value; }
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
        public double LandingStrip
        {
            get { return landingStrip; }
            set { landingStrip = value; }
        }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
                return $"Invalid drone.";
            if (Drones.Count >= Capacity)
                return $"Airfield is full.";

            Drones[drone.Name] = drone;
            // Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            return Drones.Remove(name);
            //    if (Drones.Any(x => x.Name == name))
            //    {
            //        return Drones.Remove(Drones.First(x => x.Name == name));
            //    }
            //    return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            int count = Drones.Count(x => x.Value.Brand == brand);
            foreach (var item in Drones.Where(x => x.Value.Brand == brand))
                Drones.Remove(item.Key);
            return count;
            //  return Drones.RemoveAll(x => x.Brand == brand);
        }
        public Drone FlyDrone(string name)
        {
            if (Drones.ContainsKey(name))
            {
                Drones[name].Available = false;
                return Drones[name];
            }
            return null;
            //  Drones.First(x => x.Name == name).Available = false;
            //  return Drones.First(x => x.Name == name);
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            foreach (var item in Drones.Where(x => x.Value.Range >= range))
                Drones[item.Key].Available = false;

            return Drones.Values.Where(x => x.Available == false && x.Range >= range).ToList();

            //  //  Drones.Where(x => x.Range >= range).Select(x => x.Available == false);
            //  foreach (var item in Drones.Where(x=> x.Range >= range))
            //  {
            //      item.Available = false;
            //  }
            //  return Drones.Where(x => x.Available == false && x.Range >= range).ToList();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var (droneName, drone) in this.Drones.Where(x => x.Value.Available == true))
                sb.AppendLine(drone.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
