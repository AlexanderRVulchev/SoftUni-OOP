using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    using Contracts;
    using System.Diagnostics;
    using System.Reflection.Metadata;
    using Utilities.Messages;

    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        public int size;
        private decimal price;

        public Fish(string name, string species, decimal price)
        {
            Name = name;
            Species = species;
            Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);
                name = value;
            }
        }

        public string Species
        {
            get { return species; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
                species = value;
            }
        }

        public int Size
        {
            get { return size; }
            protected set { size = value; }
        }
        
        public decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                price = value;
            }
        }

        public abstract void Eat();        
    }
}
