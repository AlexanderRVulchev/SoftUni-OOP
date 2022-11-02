

namespace _04._Wild_Farm
{
    public abstract class Feline : Mammal
    {
        protected abstract string Breed { get; set; }

        protected Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight,livingRegion)
        {
            this.Breed = breed;
        }

        public override string ToString()
        => $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
