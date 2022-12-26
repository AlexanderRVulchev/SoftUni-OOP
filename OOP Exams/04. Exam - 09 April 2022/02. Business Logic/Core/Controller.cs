
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Core
{
    using Core.Contracts;
    using Formula1.Models.Races;
    using Models.Contracts;
    using Models.FormulaOneCars;
    using Models.Pilots;
    using Repositories;
    using System.Collections;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Xml.Linq;

    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (!pilotRepository.Models.Any(x => x.FullName == pilotName) ||
                pilotRepository.Models.First(x => x.FullName == pilotName).CanRace)
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            if (!carRepository.Models.Any(x => x.Model == carModel))
                throw new NullReferenceException(String.Format(Utilities.ExceptionMessages.CarDoesNotExistErrorMessage, carModel));

            IPilot pilotToRace = pilotRepository.Models.First(x => x.FullName == pilotName);
            IFormulaOneCar carToAdd = carRepository.Models.First(x => x.Model == carModel);
            pilotToRace.AddCar(carToAdd);
            carRepository.Remove(carToAdd);
            return String.Format(Utilities.OutputMessages.SuccessfullyPilotToCar, pilotName, carToAdd.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (!raceRepository.Models.Any(x => x.RaceName == raceName))
                throw new NullReferenceException(String.Format(Utilities.ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            IRace raceToAddTo = raceRepository.Models.First(x => x.RaceName == raceName);

            if (!pilotRepository.Models.Any(x => x.FullName == pilotFullName))
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));

            IPilot pilotToAdd = pilotRepository.Models.First(x => x.FullName == pilotFullName);

            if ((!pilotToAdd.CanRace) ||
                raceToAddTo.Pilots.Any(x => x.FullName == pilotFullName))
            {
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            raceToAddTo.AddPilot(pilotToAdd);            
            return String.Format(Utilities.OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.Models.Any(x => x.Model == model))
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.CarExistErrorMessage, model));
            if (type != "Ferrari" && type != "Williams")
                throw new InvalidOperationException(string.Format(Utilities.ExceptionMessages.InvalidTypeCar, type));

            IFormulaOneCar newCar;
            if (type == "Ferrari") newCar = new Ferrari(model, horsepower, engineDisplacement);
            else newCar = new Williams(model, horsepower, engineDisplacement);

            carRepository.Add(newCar);
            return String.Format(Utilities.OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.Models.Any(x => x.FullName == fullName))
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.PilotExistErrorMessage, fullName));
            Pilot newPilot = new Pilot(fullName);
            pilotRepository.Add(newPilot);
            return String.Format(Utilities.OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.Models.Any(x => x.RaceName == raceName))
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.RaceExistErrorMessage, raceName));
            Race newRace = new Race(raceName, numberOfLaps);
            raceRepository.Add(newRace);
            return String.Format(Utilities.OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            var orderedPilots = pilotRepository.Models.OrderByDescending(x => x.NumberOfWins);
            return String.Join(Environment.NewLine, orderedPilots);
        }

        public string RaceReport()
        {
            var filteredRaces = raceRepository.Models.Where(x => x.TookPlace);
            return String.Join(Environment.NewLine, filteredRaces.Select(x => x.RaceInfo()));
        }
        public string StartRace(string raceName)
        {            
            if (!raceRepository.Models.Any(x => x.RaceName == raceName))
                throw new NullReferenceException(String.Format(Utilities.ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            IRace race = raceRepository.FindByName(raceName);
            if (race.Pilots.Count < 3)
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.InvalidRaceParticipants, raceName));
            if (race.TookPlace)
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.RaceTookPlaceErrorMessage, raceName));

            race.TookPlace = true;
            int laps = race.NumberOfLaps;
            var orderedPilots = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(laps));
            IPilot first = orderedPilots.FirstOrDefault();
            IPilot second = orderedPilots.Skip(1).FirstOrDefault();
            IPilot third = orderedPilots.Skip(2).FirstOrDefault();
            first.WinRace();

            return $"Pilot {first.FullName} wins the {raceName} race." + Environment.NewLine +
                   $"Pilot {second.FullName} is second in the {raceName} race." + Environment.NewLine +
                   $"Pilot {third.FullName} is third in the {raceName} race.";
        }
    }
}
