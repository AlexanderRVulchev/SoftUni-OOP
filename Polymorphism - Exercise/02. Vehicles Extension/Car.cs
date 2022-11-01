using System;


namespace _02._Vehicles_Extension
{
    public class Car : Vehicle
    {
        private const double CONSUMPTION_INCREASE = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + CONSUMPTION_INCREASE, tankCapacity)
        { }
    }
}
