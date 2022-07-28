using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private ICollection<Character> characters;
        private IList<Item> items;
        // private ICollection<Item> items;
        // private readonly List<Character> characters;
        // private readonly List<Item> items;

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
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            if (!this.characters.Any(x => x.Name == characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item item = items[items.Count - 1];
            this.characters.First(x => x.Name == characterName).Bag.AddItem(item);
            items.RemoveAt(items.Count - 1);

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var currCharacter = this.characters.FirstOrDefault(x => x.Name == characterName);
            //if (!this.characters.Any(x => x.Name == characterName))
            if (currCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = currCharacter.Bag.GetItem(itemName);
            currCharacter.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in this.characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
               sb.AppendLine(string.Format(SuccessMessages.CharacterStats, character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, character.IsAlive ? "Alive" : "Dead"));
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.characters.FirstOrDefault(x => x.Name == attackerName);
            Character receiver = this.characters.FirstOrDefault(x => x.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (!attacker.IsAlive || !receiver.IsAlive) 
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            if (!(attacker is IAttacker))
            {
                throw new ArgumentException(ExceptionMessages.AttackFail, attacker.Name);
            }

            ((IAttacker)attacker).Attack(receiver);

            string result = string.Format(SuccessMessages.AttackCharacter, attacker.Name, receiver.Name, attacker.AbilityPoints, receiver.Name, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor);

            if (!receiver.IsAlive)
                result += $"{Environment.NewLine}{string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name)}";

            return result;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = this.characters.FirstOrDefault(x => x.Name == healerName);
            Character healingReceiver = this.characters.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            if (healingReceiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            if (!(healer is IHealer))
            {
                throw new ArgumentException(ExceptionMessages.HealerCannotHeal, healer.Name);
            }

            ((IHealer)healer).Heal(healingReceiver);

            return string.Format(SuccessMessages.HealCharacter, healer.Name, healingReceiver.Name, healer.AbilityPoints, healingReceiver.Name, healingReceiver.Health);
        }
    }
}
