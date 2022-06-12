namespace Drones
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Airfield
    {
        private Dictionary<string, Drone> drones;
        private string name;
        private int capacity;
        private double landingStrip;

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new Dictionary<string, Drone>();
        }
        public int Count => drones.Count;
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
                return "Invalid drone.";

            if (drones.Count + 1 > this.Capacity)
                return "Airfield is full.";

            Drones[drone.Name] = drone;
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        => Drones.Remove(name);
        public int RemoveDroneByBrand(string brand)
        {
            int count = Drones.Count(x => x.Value.Brand == brand);
            foreach (var currDrone in drones.Where(x => x.Value.Brand == brand))
                Drones.Remove(currDrone.Key);

            return count;
        }
        public Drone FlyDrone(string name)
        {
            if (Drones.ContainsKey(name))
            {
                Drones[name].Available = false;
                return Drones[name];
            }
            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            foreach (var (name, drone) in Drones.Where(x => x.Value.Range >= range))
            {
                Drones[name].Available = false;
            }
            return Drones.Values.Where(x => x.Available == false && x.Range >= range).ToList();
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
