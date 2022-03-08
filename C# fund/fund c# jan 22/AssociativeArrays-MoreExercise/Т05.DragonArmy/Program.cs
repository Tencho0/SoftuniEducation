using System;
using System.Collections.Generic;

namespace Т05.DragonArmy
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int numberOfDragons = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] givenCmd = Console.ReadLine().Split();
                string dragonType = givenCmd[0];
                string dragonName = givenCmd[1];
                int indexOfNullValue = -1;
                for (int j = 2; j < 5; j++)
                {
                    if (givenCmd[j] == "null")
                    {
                        indexOfNullValue = j;
                    }
                }
                if (indexOfNullValue == -1)
                {

                }
            }
        }
    }
    public class Dragon
    {
        private const string Null = "null";
        private const int DefaultHealth = 250;
        private const int DefaultDamage = 45;
        private const int DefaultArmor = 10;

        private int health;
        private int damage;
        private int armor;
        private string name;
        public Dragon(string name, string health, string damage, string armor)
        {
            this.name = name;
            this.health = ParseHealth(health);
            this.damage = ParseDamage(damage);
            this.armor = ParseArmor(armor);
        }
        public string Name { get { return this.name; } private set { this.name = value; } }
        private bool StringIsNull(string value)
        {
            return value == Null;
        }
        private int ParseHealth(string health)
        {
            if (this.StringIsNull(health))
            {
                return DefaultHealth;
            }
            return int.Parse(health);
        }
        private int ParseDamage(string damage)
        {
            if (this.StringIsNull(damage))
            {
                return DefaultDamage;
            }
            return int.Parse(damage);
        }
        private int ParseArmor(string armor)
        {
            if (this.StringIsNull(armor))
            {
                return DefaultArmor;
            }
            return int.Parse(armor);
        }
    }
    public class DragonArmy
    {
        private Dictionary<string, Dictionary<string, Dragon>> dragonsByType;
        public void AddDragon(string type, Dragon dragon)
        {
            if (!this.dragonsByType.ContainsKey(type))
            {
                this.dragonsByType.Add(type, new Dictionary<string, Dragon>());
            }
            Dictionary<string, Dragon> dragonByName = this.dragonsByType[type];
            string dragonName = dragon.Name;
            if (!dragonByName.ContainsKey(dragon.Name))
            {
                dragonByName.Add(dragon.Name, dragon);
            }
            else
            {

            }
        }
    }
}

//public string Type { get; set; }
//public string Name { get; set; }
//public int Damage { get { return this.damage; } set { this.damage = value; } }
//public int Health { get { return this.health; } set { this.health = value; } }
//public int Armor { get { return this.armor; } set { this.armor = value; } }