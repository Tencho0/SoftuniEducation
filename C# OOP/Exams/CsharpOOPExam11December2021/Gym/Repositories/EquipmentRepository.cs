namespace Gym.Repositories
{
    using Gym.Models.Equipment;
    using Gym.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class EquipmentRepository : IRepository<Equipment>
    {
        private List<Equipment> models;
        public IReadOnlyCollection<Equipment> Models { get { return this.models.AsReadOnly(); } }

        public void Add(Equipment model)
        {
            this.models.Add(model);
        }

        public Equipment FindByType(string type)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(Equipment model)
        {
            return this.models.Remove(model);
        }
    }
}
