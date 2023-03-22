using System;
using System.Collections.Generic;
using System.Linq;


namespace WarCroft.Entities.Inventory
{
    using Constants;
    using Entities.Items;

    public abstract class Bag : IBag
    {
        private List<Item> items;

        public Bag(int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity { get; set; } = 100;

        public int Load => items.Select(x => x.Weight).Sum();

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            items.Add(item);
        }

        public Item GetItem(string name)
        {            
            if (!items.Any())
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            Item item = items.Find(x => x.GetType().Name == name);
            if (item == null)
                throw new ArgumentException(String.Format(ExceptionMessages.ItemNotFoundInBag, name));
            items.Remove(item);
            return item;
        }
    }
}
