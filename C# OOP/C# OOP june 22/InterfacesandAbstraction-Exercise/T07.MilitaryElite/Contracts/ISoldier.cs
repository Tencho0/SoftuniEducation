using System;
using System.Collections.Generic;
using System.Text;

namespace T07.MilitaryElite.Contracts
{
    public interface ISoldier
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
