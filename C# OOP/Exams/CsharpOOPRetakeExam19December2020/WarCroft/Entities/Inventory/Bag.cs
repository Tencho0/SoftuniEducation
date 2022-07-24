using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private ICollection<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity { get; set; } = 100;

        public int Load => items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => items.ToList().AsReadOnly();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);

            if (!this.Items.Any(x => x.GetType().Name == name))
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));

            Item itemToRemove = items.First(x => x.GetType().Name == name);
            this.items.Remove(itemToRemove);
            return itemToRemove;
        }
    }
}
