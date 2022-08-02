namespace Heroes.Models.Weapons
{
    using global::Heroes.Models.Contracts;
    using System;

    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;

        public Weapon(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"Weapon type cannot be null or empty.");

                name = value;
            }
        }
        public int Durability
        {
            get { return durability; }
            protected set
            {
                if (value < 0)
                    throw new ArgumentException($"Durability cannot be below 0.");
                durability = value;
            }
        }
        public abstract int DoDamage();
    }
}
