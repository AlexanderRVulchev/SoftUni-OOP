
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    using Models.Contracts;
    using Repositories.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> pilots;

        public PilotRepository()
        {
            pilots = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => pilots.AsReadOnly();

        public void Add(IPilot model)
        {
            pilots.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return pilots.Find(x => x.FullName == name);
        }

        public bool Remove(IPilot model)
        {
            return pilots.Remove(model);
        }
    }
}
