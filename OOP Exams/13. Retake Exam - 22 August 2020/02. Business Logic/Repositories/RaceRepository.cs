
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories
{
    using EasterRaces.Models.Races.Contracts;
    using Models.Races.Entities;
    using Repositories.Entities;
    using System.Linq;

    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        => Models.FirstOrDefault(x => x.Name == name);
    }
}
