using System;

namespace _04._Wild_Farm
{
    public abstract class Animal
    {
        protected abstract string Name { get; set; }
        protected abstract double Weight { get; set; }
        protected abstract int FoodEaten { get; set; }
        protected abstract double WeightGain { get; }

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public abstract string Sound();
        public abstract void Eat(Food food);
    }
}
