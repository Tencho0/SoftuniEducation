namespace T07.MilitaryElite.Model
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Enums;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IRepairs> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public ICollection<IRepairs> Repairs { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");
            foreach (var item in Repairs)
                sb.AppendLine($"  {item}");

            return sb.ToString().TrimEnd();
        }
    }
}
