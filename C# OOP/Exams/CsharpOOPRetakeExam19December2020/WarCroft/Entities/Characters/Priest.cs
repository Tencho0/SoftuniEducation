﻿namespace WarCroft.Entities.Characters
{
    using System;
    using WarCroft.Constants;
    using WarCroft.Entities.Characters.Contracts;
    using WarCroft.Entities.Inventory;

    public class Priest : Character, IHealer
    {
        public Priest(string name) 
            : base(name, 50, 25, 40, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                character.Health += this.AbilityPoints;
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}
