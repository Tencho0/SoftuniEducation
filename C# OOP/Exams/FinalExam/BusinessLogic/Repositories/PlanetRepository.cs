namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> models;

        public PlanetRepository()
        {

            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => (IReadOnlyCollection<IPlanet>)models;

        public void AddItem(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveItem(string name)
        {
            var model = this.models.FirstOrDefault(x => x.Name == name);

            if (model == null)
                return false;

            return this.models.Remove(model);
        }
    }
}
