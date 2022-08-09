namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private ICollection<string> targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);

                name = value;
            }
        }

        public ICaptain Captain
        {
            get { return captain; }
            set
            {
                if (value == null)
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);

                captain = value;
            }
        }
        public double ArmorThickness
        {
            get { return armorThickness; }
            set { armorThickness = value; }
        }

        public double MainWeaponCaliber
        {
            get { return mainWeaponCaliber; }
            protected set { mainWeaponCaliber = value; }
        }

        public double Speed
        {
            get { return speed; }
            protected set { speed = value; }
        }

        public ICollection<string> Targets
        {
            get { return targets; }
            private set { targets = value; }
        }

        public void Attack(IVessel target)
        {
            if (target == null)
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);

            target.ArmorThickness -= this.MainWeaponCaliber;
            if (target.ArmorThickness < 0)
                target.ArmorThickness = 0;

            this.Targets.Add(target.Name);
        }

        public void RepairVessel()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.speed} knots");
            sb.Append($" *Targets: " + (this.Targets.Count == 0 ? "None" : string.Join(", ", this.Targets)));

            return sb.ToString().TrimEnd();
        }
    }
}
