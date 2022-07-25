﻿using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private ICollection<Character> characters;
        private ICollection<Item> items;

        public WarController()
        {
            characters = new List<Character>();
            items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character;
            if (characterType == "Warrior")
                character = new Warrior(name);
            else if (characterType == "Priest")
                character = new Priest(name);
            else
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));

            characters.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item;
            if (itemName == nameof(FirePotion))
                item = new FirePotion();
            else if (itemName == nameof(HealthPotion))
                item = new HealthPotion();
            else
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));

            this.items.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName));
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            if (!this.characters.Any(x=> x.Name == characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

        }

        public string UseItem(string[] args)
        {
            throw new NotImplementedException();
        }

        public string GetStats()
        {
            throw new NotImplementedException();
        }

        public string Attack(string[] args)
        {
            throw new NotImplementedException();
        }

        public string Heal(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
