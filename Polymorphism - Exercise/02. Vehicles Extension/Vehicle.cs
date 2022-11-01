using System;


namespace _02._Vehicles_Extension
{
    public class Vehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumption;
        protected double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.fuelConsumption = fuelConsumption;
            this.tankCapacity = tankCapacity;

            if (fuelQuantity <= tankCapacity)
                this.fuelQuantity = fuelQuantity;
        }

        public virtual void Drive(double km)
        {
            double newFuelAmount = this.fuelQuantity - this.fuelConsumption * km;
            if (newFuelAmount < 0)
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            else
            {
                this.fuelQuantity = newFuelAmount;
                Console.WriteLine($"{this.GetType().Name} travelled {km} km");
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
                Console.WriteLine("Fuel must be a positive number");
            else if (this.fuelQuantity + liters > this.tankCapacity)
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            else
                this.fuelQuantity += liters;
        }

        public override string ToString()
        => $"{this.GetType().Name}: {this.fuelQuantity:f2}";
    }
}
