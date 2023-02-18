using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        public ProfessionalRacer(string username, ICar car)
            : base(username, "strict", 30, car)
        { }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 10;
        }
    }
}
