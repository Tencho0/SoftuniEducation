namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private ICollection<IAstronaut> models;

        public IReadOnlyCollection<IAstronaut> Models => (IReadOnlyCollection<IAstronaut>)models;

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
            return this.models.Remove(model);
        }
    }
}
