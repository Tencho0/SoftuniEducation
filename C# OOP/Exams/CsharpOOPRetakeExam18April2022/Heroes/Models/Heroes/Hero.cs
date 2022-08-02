namespace Heroes.Models.Heroes
{
    using global::Heroes.Models.Contracts;
    using System;

    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public bool IsAlive => this.Health > 0;
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"Hero name cannot be null or empty.");

                name = value;
            }
        }
        public int Health
        {
            get { return health; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException($"Hero health cannot be below 0.");

                health = value;
            }
        }
        public int Armour
        {
            get { return armour; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException($"Hero armour cannot be below 0.");

                armour = value;
            }
        }
        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                if (value == null)
                    throw new ArgumentException($"Weapon cannot be null.");

                weapon = value;
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            if (this.Armour - points >= 0)
            {
                this.Armour -= points;
            }
            else if (this.Armour - points < 0)
            {
                this.Health -= (points - this.Armour);
                this.Armour = 0;
            }

            if (this.Health < 0)
                this.Health = 0;
        }
    }
}
