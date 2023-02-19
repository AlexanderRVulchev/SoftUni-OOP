using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Repositories
{
    using Models.Racers.Contracts;
    using Contracts;
    using Utilities.Messages;

    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => models.AsReadOnly();

        public void Add(IRacer model)
        {
            if (model == null)
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            models.Add(model);
        }

        public IRacer FindBy(string property)
        => models.Find(x => x.Username == property);

        public bool Remove(IRacer model)
        => models.Remove(model);
    }
}
