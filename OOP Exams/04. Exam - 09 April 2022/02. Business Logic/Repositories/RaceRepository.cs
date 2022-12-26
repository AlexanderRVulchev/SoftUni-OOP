
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Repositories.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => races.AsReadOnly();

        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IRace FindByName(string name)
        {
            return races.Find(x => x.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return races.Remove(model);
        }
    }
}
