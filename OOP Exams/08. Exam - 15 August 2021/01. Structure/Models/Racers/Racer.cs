using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using Contracts;
    using System.Net.NetworkInformation;
    using Utilities.Messages;

    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehaviour;
        private int drivingExperience;
        private ICar car;

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                username = value;
            }
        }
        
        public string RacingBehavior
        {
            get { return racingBehaviour; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                racingBehaviour = value;
            }
        }
        
        public int DrivingExperience
        {
            get { return drivingExperience; }
            protected set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                drivingExperience = value;
            }
        }
 
        public ICar Car
        {
            get { return car; }
            private set
            {
                if (value == null)
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);                
                car = value;
            }
        }

        public bool IsAvailable()        
        => car.FuelConsumptionPerRace <= car.FuelAvailable;        
        
        public virtual void Race()
        {
            car.Drive();
        }
    }
}
