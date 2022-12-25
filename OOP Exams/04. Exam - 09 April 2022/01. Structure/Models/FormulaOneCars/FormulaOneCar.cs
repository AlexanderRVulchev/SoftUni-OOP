
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.FormulaOneCars
{    
    using Models.Contracts;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double engineDisplacement;

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                    throw new ArgumentException(string.Format(Utilities.ExceptionMessages.InvalidF1CarModel, value));
                model = value;
            }
        }

        public int Horsepower
        {
            get { return horsepower; }
            private set
            {
                if (value < 900 || value > 1050)
                    throw new ArgumentException(string.Format(Utilities.ExceptionMessages.InvalidF1HorsePower, value));
                horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get { return engineDisplacement; }
            private set
            {
                if (value < 1.60 || value > 2.00)
                    throw new ArgumentException(string.Format(Utilities.ExceptionMessages.InvalidF1EngineDisplacement, value));
                engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        => EngineDisplacement / Horsepower * laps;
    }
}
