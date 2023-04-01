using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    using Contracts;
    using EasterRaces.Utilities.Messages;
    

    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsePower;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            HorsePower = horsePower;
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel, value, 4));
                model = value;
            }
        }
        
        public virtual int HorsePower
        {
            get { return horsePower; }
            private set
            {
                if (value < minHorsePower || value > maxHorsePower)
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                horsePower = value;
            }
        }

        public double CubicCentimeters
        {
            get { return cubicCentimeters; }
            private set { cubicCentimeters = value; }
        }

        public double CalculateRacePoints(int laps)
        => CubicCentimeters / HorsePower * laps;
    }
}
