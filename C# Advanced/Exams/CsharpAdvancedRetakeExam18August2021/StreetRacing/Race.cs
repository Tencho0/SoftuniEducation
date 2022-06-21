using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private Dictionary<string, Car> participants;
        private string name;
        private string type;
        private int laps;
        private int capacity;
        private int maxHorsePower;
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new Dictionary<string, Car>();
        }
        public int Count => participants.Count;
        public Dictionary<string, Car> Participants
        {
            get { return participants; }
            set { participants = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Laps
        {
            get { return laps; }
            set { laps = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public int MaxHorsePower
        {
            get { return maxHorsePower; }
            set { maxHorsePower = value; }
        }
        public void Add(Car car)
        {
            if ((!Participants.ContainsKey(car.LicensePlate)) && Participants.Count < this.Capacity && car.HorsePower <= maxHorsePower)
            {
                Participants[car.LicensePlate] = car;
            }
        }
        public bool Remove(string licensePlate)
        {
            return Participants.Remove(licensePlate);
        }
        public Car FindParticipant(string licensePlate)
        {
            if (Participants.ContainsKey(licensePlate))
                return Participants[licensePlate];
            return null;
        }
        public Car GetMostPowerfulCar()
        {
            if (Participants.Count == 0)
                return null;

            int max = Participants.Values.Max(x => x.HorsePower);
            return Participants.Values.First(x => x.HorsePower >= max);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var (licence, participant) in Participants)
                sb.AppendLine(participant.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
