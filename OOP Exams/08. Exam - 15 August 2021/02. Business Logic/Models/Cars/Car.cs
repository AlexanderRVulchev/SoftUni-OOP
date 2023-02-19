
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    using Models.Cars.Contracts;    
    using Utilities.Messages;

    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        public Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
            this.VIN = VIN;
        }

        public string Make
        {
            get { return make; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                make = value;
            }
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                model = value;
            }
        }

        public string VIN
        {
            get { return vin; }
            private set
            {
                if (value.Length != 17)
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                vin = value;
            }
        }

        public int HorsePower
        {
            get { return horsePower; }
            protected set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                horsePower = value;
            }
        }
        
        public double FuelAvailable
        {
            get { return fuelAvailable; }
            private set
            {
                if (value < 0)
                    fuelAvailable = 0;
                else
                    fuelAvailable = value;
            }
        }
        
        public double FuelConsumptionPerRace
        {
            get { return fuelConsumptionPerRace; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                fuelConsumptionPerRace = value;
            }
        }

        public virtual void Drive()
        {            
            FuelAvailable -= FuelConsumptionPerRace;
        }
    }
}
