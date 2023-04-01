using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories
{
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Drivers.Entities;
    using EasterRaces.Repositories.Entities;
    using System.Linq;

    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name)
        => Models.FirstOrDefault(x => x.Name == name);
    }
}
