namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Heroes.Models.Contracts;
    using Heroes.Models.Weapons;
    using Heroes.Repositories.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)models;

        public void Add(IWeapon model)
        {
            models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            return models.Remove(model);
        }
    }
}
