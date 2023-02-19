using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class StreetRacer : Racer
    {
        public StreetRacer(string username, ICar car)
            : base(username, "aggressive", 10, car)
        { }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}
