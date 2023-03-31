using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{

    using Contracts;
    using EasterRaces.Models.Cars.Contracts;    
    using EasterRaces.Utilities.Messages;

    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private int numberOfWins;
        private bool canParticipate;

        public Driver(string name)
        {
            Name = name;
            CanParticipate = false;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, 5));
                name = value;
            }
        }

        public ICar Car
        {
            get { return car; }
            private set 
            {
                if (value == null)
                    throw new ArgumentNullException(ExceptionMessages.CarInvalid);
                car = value; 
            }
        }

        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set { numberOfWins = value; }
        }

        public bool CanParticipate
        {
            get { return canParticipate; }
            private set { canParticipate = value; }
        }

        public void AddCar(ICar car)
        {            
            Car = car;
            CanParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
