using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        public Biologist(string name)
            : base(name, 70)
        { }

        public override void Breath()
        {
            Oxygen = Math.Max(Oxygen - 5, 0);
        }
    }
}
