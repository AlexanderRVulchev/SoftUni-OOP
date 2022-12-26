
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Pilots
{
    using Models.Contracts;

    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;

        public Pilot(string fullName)
        {
            FullName = fullName;
            CanRace = false;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                    throw new ArgumentException(string.Format(Utilities.ExceptionMessages.InvalidPilot, value));
                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get
            { return car; }
            private set
            {
                if (value == null)
                    throw new NullReferenceException(string.Format(Utilities.ExceptionMessages.InvalidCarForPilot));
                car = value;
            }
        }

        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set { numberOfWins = value; }
        }

        public bool CanRace { get; private set; }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}
