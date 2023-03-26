using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    using Bakery.Utilities.Messages;
    using Contracts;

    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;

        public BakedFood(string name, int portion, decimal price)
        {
            Name = name;
            Portion = portion;
            Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                name = value;
            }
        }

        public int Portion
        {
            get { return portion; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                portion = value;
            }
        }

        public decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                price = value;
            }
        }

        public override string ToString()
        => $"{Name}: {Portion}g - {Price:f2}";
    }
}
