using System;

namespace _04._Wild_Farm
{
    public class Owl : Bird
    {
        protected override double WeightGain => 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        { }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                this.Weight += WeightGain * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        public override string Sound()
        => "Hoot Hoot";
    }
}
