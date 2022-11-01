using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles
{
    public class Car : Vehicle
    {
        private const double CONSUMPTION_INCREASE = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + CONSUMPTION_INCREASE)
        { }
    }
}
