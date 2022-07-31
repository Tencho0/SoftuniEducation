namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Heroes.Models.Contracts;
    using Heroes.Models.Weapons;
    using Heroes.Repositories.Contracts;

    public class WeaponRepository : IRepository<Weapon>
    {
        private readonly ICollection<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<Weapon> Models => (IReadOnlyCollection<Weapon>)models;

        public void Add(Weapon model)
        {
            models.Add(model);
        }

        public Weapon FindByName(string name)
        {
            return (Weapon)models.FirstOrDefault(x => (x as Weapon).Name == name);
        }

        public bool Remove(Weapon model)
        {
            return models.Remove(model);
        }
    }
}
