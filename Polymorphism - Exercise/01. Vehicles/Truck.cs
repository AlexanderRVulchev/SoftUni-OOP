using System;


namespace _01._Vehicles
{
    public class Truck : Vehicle
    {
        private const double REFUEL_MODIFIER = 0.95;
        private const double CONSUMPTION_INCREASE = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + CONSUMPTION_INCREASE)
        { }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * REFUEL_MODIFIER);
        }
    }
}
