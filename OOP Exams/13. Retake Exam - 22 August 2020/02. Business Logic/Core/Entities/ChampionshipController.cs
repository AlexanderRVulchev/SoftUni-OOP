using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Core.Entities
{
    using Core.Contracts;
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Cars.Entities;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Drivers.Entities;
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Models.Races.Entities;
    using EasterRaces.Repositories;
    using EasterRaces.Utilities.Messages;
    using System.Linq;

    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;

        public ChampionshipController()
        {
            cars = new CarRepository();
            drivers = new DriverRepository();
            races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!drivers.Models.Any(x => x.Name == driverName))
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            if (!cars.Models.Any(x => x.Model == carModel))
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            IDriver driver = drivers.GetByName(driverName);
            ICar car = cars.GetByName(carModel);
            driver.AddCar(car);
            return String.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!races.Models.Any(x => x.Name == raceName))
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            if (!drivers.Models.Any(x => x.Name == driverName))
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            IRace race = races.GetByName(raceName);
            IDriver driver = drivers.GetByName(driverName);
            race.AddDriver(driver);
            return String.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (cars.Models.Any(x => x.Model == model))
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model));
            ICar car = null;
            if (type == "Muscle") car = new MuscleCar(model, horsePower);
            else if (type == "Sports") car = new SportsCar(model, horsePower);
            cars.Add(car);
            return String.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            if (drivers.Models.Any(x => x.Name == driverName))
                throw new ArgumentException(String.Format(ExceptionMessages.DriversExists, driverName));

            IDriver driver = new Driver(driverName);
            drivers.Add(driver);
            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (races.Models.Any(x => x.Name == name))
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name)); 
            IRace race = new Race(name, laps);
            races.Add(race);
            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {            
            if (!races.Models.Any(x => x.Name == raceName))
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            IRace race = races.GetByName(raceName);
            if (race.Drivers.Count < 3)
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, 3));

            var drivers = race.Drivers
                .OrderByDescending(x => x.Car
                .CalculateRacePoints(race.Laps))
                .Take(3);
            IDriver firstPlace = drivers.First();
            IDriver secondPlace = drivers.Skip(1).First();
            IDriver thirdPlace = drivers.Last();

            races.Remove(race);
            return String.Format(OutputMessages.DriverFirstPosition, firstPlace.Name, raceName) + Environment.NewLine +
                   String.Format(OutputMessages.DriverSecondPosition, secondPlace.Name, raceName) + Environment.NewLine +
                   String.Format(OutputMessages.DriverThirdPosition, thirdPlace.Name, raceName);
        }
    }
}
