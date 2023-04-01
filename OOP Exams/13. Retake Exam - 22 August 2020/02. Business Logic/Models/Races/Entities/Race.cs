using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    using Models.Drivers.Contracts;    
    using Models.Races.Contracts;
    using Utilities.Messages;

    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IDriver> drivers;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            this.drivers = new List<IDriver>();
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

        public int Laps
        {
            get { return laps; }
            private set
            {
                if (value < 1)
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {            
            if (driver == null)
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            if (!driver.CanParticipate)
                throw new ArgumentException(String.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            if (drivers.Contains(driver))
                throw new ArgumentNullException(String.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            drivers.Add(driver);
        }
    }
}
