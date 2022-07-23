namespace Gym.Repositories
{
    using Gym.Models.Equipment;
    using Gym.Models.Equipment.Contracts;
    using Gym.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> models;
        public IReadOnlyCollection<IEquipment> Models { get { return this.models.AsReadOnly(); } }
        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }
        public void Add(IEquipment model)
        {
            this.models.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IEquipment model)
        {
            return this.models.Remove(model);
        }
    }
}
