using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public double CoffeeMilliliters { get { return 50; }  }
        public decimal CoffeePrice { get { return 3.50M; } }
        public double Caffeine { get; set; }

        public override decimal Price { get { return this.CoffeePrice; } }
        public override double Milliliters { get { return this.CoffeeMilliliters; } }

        public Coffee(string name, double caffeine) 
            : base(name, 0, 0)
        {            
            this.Caffeine = caffeine;
        }
    }
}
