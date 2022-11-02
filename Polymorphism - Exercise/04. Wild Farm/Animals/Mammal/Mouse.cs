using System;


namespace _04._Wild_Farm
{
    public class Mouse : Mammal
    {
        protected override string LivingRegion { get; set; }
        protected override string Name { get; set; }
        protected override double Weight { get; set; }
        protected override int FoodEaten { get; set; }

        protected override double WeightGain => 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight,livingRegion)
        { }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Fruit")
            {
                this.Weight += WeightGain * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        public override string Sound()
        => "Squeak";
    }
}
