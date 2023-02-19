using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Racers;
    using CarRacing.Models.Racers.Contracts;
    using Contracts;
    using Utilities.Messages;

    public class Map : IMap
    {
        private const double STRICT_MOD = 1.2;
        private const double AGGRESSIVE_MOD = 1.1;

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {            
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
                return OutputMessages.RaceCannotBeCompleted;
            else if (!racerTwo.IsAvailable())
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            else if (!racerOne.IsAvailable())
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);

            racerOne.Race();
            racerTwo.Race();
            double racerOneScore = DriveAndGetRacerScore(racerOne);
            double racerTwoScore = DriveAndGetRacerScore(racerTwo);
            IRacer winner = racerOneScore > racerTwoScore ? racerOne : racerTwo;            

            return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
        }

        private double DriveAndGetRacerScore(IRacer racer)
        {
            double racerMultiplier = racer.RacingBehavior == "strict" ? STRICT_MOD : AGGRESSIVE_MOD;
            return racer.Car.HorsePower * racer.DrivingExperience * racerMultiplier;
        }
    }
}
