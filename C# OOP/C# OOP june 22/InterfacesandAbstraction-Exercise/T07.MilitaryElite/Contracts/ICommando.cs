namespace T07.MilitaryElite.Contracts
{
    using System.Collections.Generic;
    public interface ICommando : ISpecialisedSoldier
    {
        ICollection<IMission> Missions { get; set; }
    }
}
