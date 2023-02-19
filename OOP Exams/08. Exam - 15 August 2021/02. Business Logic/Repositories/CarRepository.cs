using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Repositories
{
    using Models.Cars.Contracts;
    using Contracts;
    using Utilities.Messages;
    
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => models.AsReadOnly();

        public void Add(ICar model)
        {
            if (model == null)
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            models.Add(model);
        }
        
        public ICar FindBy(string property)
        => models.Find(x => x.VIN == property);

        public bool Remove(ICar model)
        => models.Remove(model);
    }
}
