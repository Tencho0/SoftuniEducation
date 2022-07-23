namespace Gym.Models.Gyms
{
    using Athletes.Contracts;
    using Equipment.Contracts;
    using global::Gym.Utilities.Messages;
    using Gyms.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            Equipment = new List<IEquipment>();
            Athletes = new List<IAthlete>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }
        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }
        public ICollection<IEquipment> Equipment { get; }
        public ICollection<IAthlete> Athletes { get; }
        public double EquipmentWeight
        {
            get { return Equipment.Sum(x => x.Weight); }
        }
        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count >= this.Capacity)
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            this.Athletes.Add(athlete);
        }
        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.Athletes.Remove(athlete);
        }
        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }
        public void Exercise()
        {
            foreach (var currAthlete in Athletes)
            {
                currAthlete.Exercise();
            }
        }
        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            if (this.Athletes.Count > 0)
                sb.AppendLine($"Athletes: {string.Join(", ", this.Athletes.Select(x => x.FullName))}");
            else
                sb.AppendLine("Athletes: No athletes");
            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:F2} grams");

            return sb.ToString().TrimEnd();
        }
    }
}
