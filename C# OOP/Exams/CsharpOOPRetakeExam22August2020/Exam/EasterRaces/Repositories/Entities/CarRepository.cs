namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using System.Linq;

    public class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name)
            => this.GetAll().FirstOrDefault(x => x.Model == name);
    }
}
