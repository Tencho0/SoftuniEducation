namespace AquaShop.Repositories
{
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly ICollection<IDecoration> models;

        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => (IReadOnlyCollection<IDecoration>)models;

        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            var decoration = models.FirstOrDefault(x => x.GetType().Name == type);

            if (decoration != null)
                models.Remove(decoration);

            return decoration;
        }

        public bool Remove(IDecoration model)
        {
            return models.Remove(model);
        }
    }
}
