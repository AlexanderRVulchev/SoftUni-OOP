using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public decimal CakePrice { get { return 5; } }
        public override double Grams { get { return 250; } }
        public override double Calories { get { return 1000; } }
        public override decimal Price { get { return this.CakePrice; } }

        public Cake(string name)
            : base(name, 0, 0, 0)
        { }

    }
}
