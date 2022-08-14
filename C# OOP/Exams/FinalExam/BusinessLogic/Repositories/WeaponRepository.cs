namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)models;

        public void AddItem(IWeapon model)
        {
            this.models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            var model = this.models.FirstOrDefault(x => x.GetType().Name == name);
            
            if (model == null)
                return false;

            return this.models.Remove(model);
        }
    }
}
