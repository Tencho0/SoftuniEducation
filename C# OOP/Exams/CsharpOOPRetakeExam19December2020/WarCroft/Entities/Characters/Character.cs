using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public bool IsAlive { get; set; } = true;
        public double BaseHealth { get; set; }
        public double BaseArmor { get; set; }
        public double AbilityPoints { get; set; }
        public Bag Bag { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }
        public double Health
        {
            get { return health; }
            set
            {
                health = value;

                if (health < 0)
                {
                    health = 0;
                    IsAlive = false;
                }

                if (health > BaseHealth)
                    health = BaseHealth;

                //    if (value > 0 && value <= BaseHealth)
                //        health = value;
                //
                //    if (value == 0)
                //        IsAlive = false;
            }
        }
        public double Armor
        {
            get { return armor; }
            set
            {
                armor = value;
                if (armor < 0)
                    armor = 0;

                // if (value >= 0)
                //    armor = value;
            }
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
            else
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
        }
        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                if (this.Armor - hitPoints >= 0)
                {
                    this.Armor -= hitPoints;
                }
                else
                {
                    this.Health -= (hitPoints - this.Armor);
                    this.Armor = 0;
                }
            }
        }
    }
}