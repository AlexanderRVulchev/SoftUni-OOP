using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Workshops
{
    using Contracts;
    using Easter.Models.Dyes.Contracts;
    using Models.Bunnies.Contracts;
    using Models.Eggs.Contracts;
    using System.Linq;

    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {            
            while (!egg.IsDone() && bunny.Dyes.Any(x => !x.IsFinished()) && bunny.Energy > 0)
            {
                IDye dye = bunny.Dyes.FirstOrDefault(x => !x.IsFinished());
                dye.Use();
                egg.GetColored();
                bunny.Work();               
            }
        }
    }
}
