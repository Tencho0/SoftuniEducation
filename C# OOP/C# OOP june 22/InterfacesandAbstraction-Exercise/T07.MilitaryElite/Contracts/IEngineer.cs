using System;
using System.Collections.Generic;
using System.Text;

namespace T07.MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public ICollection<IRepairs> Repairs { get; set; }
    }
}
