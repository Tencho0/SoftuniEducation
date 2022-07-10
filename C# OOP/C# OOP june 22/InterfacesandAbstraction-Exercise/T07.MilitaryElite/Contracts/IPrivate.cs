using System;
using System.Collections.Generic;
using System.Text;

namespace T07.MilitaryElite.Contracts
{
    public interface IPrivate : ISoldier
    {
        public decimal Salary { get; set; }
    }
}
