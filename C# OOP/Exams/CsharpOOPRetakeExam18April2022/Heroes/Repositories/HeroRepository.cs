namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Heroes.Models.Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Repositories.Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly ICollection<IHero> models;
        public HeroRepository()
        {
            models = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => (IReadOnlyCollection<IHero>)models;

        public void Add(IHero model)
        {
            models.Add(model);
        }

        public IHero FindByName(string name)
        {
            return models.FirstOrDefault(x => (x as Hero).Name == name);
        }

        public bool Remove(IHero model)
        {
            return models.Remove(model);
        }
    }
}
