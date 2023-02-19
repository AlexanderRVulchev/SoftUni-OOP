
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Core
{
    using Repositories;
    using Contracts;
    using Models.Maps.Contracts;
    using Models.Maps;
    using CarRacing.Models.Cars;
    using Utilities.Messages;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Racers;
    using CarRacing.Models.Racers.Contracts;
    using System.Diagnostics;
    using System.Linq;

    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar carToAdd;
            switch (type)
            {
                case "SuperCar": carToAdd = new SuperCar(make, model, VIN, horsePower); break;
                case "TunedCar": carToAdd = new TunedCar(make, model, VIN, horsePower); break;
                default: throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            cars.Add(carToAdd);
            return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);
            if (car == null)
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            IRacer racer;
            switch (type)
            {
                case "ProfessionalRacer": racer = new ProfessionalRacer(username, car); break;
                case "StreetRacer": racer = new StreetRacer(username, car); break;
                default: throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
            racers.Add(racer);
            return String.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer first = racers.FindBy(racerOneUsername);
            if (first == null)
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            IRacer second = racers.FindBy(racerTwoUsername);
            if (second == null)
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            return map.StartRace(first, second);
        }

        public string Report()
        => String.Join(Environment.NewLine, racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username));
    }
}
