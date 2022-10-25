using System;
using System.Collections.Generic;


namespace _03._Shopping_Spree
{
    public class Person
    {
        // Fields
        private string name;
        private decimal money;
        private readonly List<Product> bag;

        // Properties
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                name = value;
            }
        }
        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");
                money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag { get { return bag.AsReadOnly(); } }

        // Constructors
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        // Methods
        public void BuyProduct(Product product)
        {
            if (this.money >= product.Cost)
            {
                Console.WriteLine($"{this.Name} bought {product}");
                this.money -= product.Cost;
                this.bag.Add(product);
            }
            else
                Console.WriteLine($"{this.Name} can't afford {product}");
        }
    }
}
