namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Repositories.Contracts;
    using System.Collections.Generic;

    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private ICollection<T> models;

        protected Repository()
        {
            models = new List<T>();
        }

        public void Add(T model) => this.models.Add(model);

        public IReadOnlyCollection<T> GetAll() => models as IReadOnlyCollection<T>;

        public abstract T GetByName(string name);

        public bool Remove(T model) => this.models.Remove(model);
    }
}
