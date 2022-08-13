namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Models.Drivers.Contracts;
    using System.Linq;

    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name) 
            => this.GetAll().FirstOrDefault(x => x.Name == name);
    }
}
