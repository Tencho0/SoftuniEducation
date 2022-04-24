namespace MilitaryElite
{
    using System.Collections.Generic;
    public interface IEngineer : ISpecialisedSoldier
    {
        ICollection<IRepairs> Repairs { get; set; }
    }
}
