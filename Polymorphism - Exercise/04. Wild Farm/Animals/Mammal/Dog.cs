using System;


namespace _04._Wild_Farm
{
    public class Dog : Mammal
    {
        protected override string LivingRegion { get; set; }
        protected override string Name { get; set; }
        protected override double Weight { get; set; }
        protected override int FoodEaten { get; set; }

        protected override double WeightGain => 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight,livingRegion)
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
        => "Woof!";
    }
}
