using System;


namespace _03._Shopping_Spree
{
    public class Product
    {
        // Fields
        private string name;
        private decimal cost;

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

        public decimal Cost 
        { 
            get { return cost; }            
            set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");
                cost = value;
            }

        }

        // Constructors
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        // Methods
        public override string ToString()
        => this.Name;
    }
}
