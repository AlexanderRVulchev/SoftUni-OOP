using System;


namespace _04._Wild_Farm
{
    public abstract class Mammal : Animal
    {
        protected abstract string LivingRegion { get; set; }

        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public override string ToString()
        => $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
