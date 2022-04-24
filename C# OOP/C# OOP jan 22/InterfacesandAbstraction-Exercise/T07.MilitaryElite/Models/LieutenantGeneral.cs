using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, Dictionary<int, IPrivate> privates)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }
        public Dictionary<int, IPrivate> Privates { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var item in Privates)
            {
                sb.AppendLine($" {item.Value.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
