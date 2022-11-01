using System;


namespace _01._Vehicles
{
    public class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;        

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
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
            this.fuelQuantity += liters;
        }

        public override string ToString()
        => $"{this.GetType().Name}: {this.fuelQuantity:f2}";
    }
}
