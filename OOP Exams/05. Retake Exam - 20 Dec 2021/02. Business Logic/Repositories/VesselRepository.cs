using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Repositories
{
    using Models.Contracts;
    using Repositories.Contracts;
    
    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> vessels;

        public VesselRepository()
        {
            vessels = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => vessels.AsReadOnly();

        public void Add(IVessel model)
        {
            vessels.Add(model);
        }

        public IVessel FindByName(string name)
        {
            return vessels.Find(x => x.Name == name);
        }

        public bool Remove(IVessel model)
        {
            return vessels.Remove(model);
        }
    }
}
