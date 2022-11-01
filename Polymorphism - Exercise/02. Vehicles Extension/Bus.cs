using System;


namespace _02._Vehicles_Extension
{
    public class Bus : Vehicle
    {
        private const double CONSUMPTION_INCREASE = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        { }

        public override void Drive(double km)
        {
            base.fuelConsumption += CONSUMPTION_INCREASE;
            base.Drive(km);
            base.fuelConsumption -= CONSUMPTION_INCREASE;
        }

        public void DriveEmpty(double km)
        {
            base.Drive(km);
        }
    }
}
