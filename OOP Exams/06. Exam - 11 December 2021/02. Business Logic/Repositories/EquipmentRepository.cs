
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Repositories
{
    using Models.Equipment.Contracts;
    using Repositories.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> equipment;

        public EquipmentRepository()
        {
            equipment = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => equipment.AsReadOnly();

        public void Add(IEquipment model)
        {
            equipment.Add(model);
        }

        public IEquipment FindByType(string type)
        => equipment.Find(x => x.GetType().Name == type);
        

        public bool Remove(IEquipment model)
        => equipment.Remove(model);
    }
}
