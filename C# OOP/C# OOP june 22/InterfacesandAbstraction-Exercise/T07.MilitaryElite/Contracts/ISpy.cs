using System;
using System.Collections.Generic;
using System.Text;

namespace T07.MilitaryElite.Contracts
{
    public interface ISpy : ISoldier
    {
        public int CodeNumber { get; set; }
    }
}
