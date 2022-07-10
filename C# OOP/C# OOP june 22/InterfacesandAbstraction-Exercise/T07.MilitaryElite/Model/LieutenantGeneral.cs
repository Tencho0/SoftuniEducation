namespace T07.MilitaryElite.Model
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class LieutenantGeneral : Private
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            Privates = new Dictionary<int, IPrivate>();
        }

        public Dictionary<int, IPrivate> Privates { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Privates:");
            foreach (var item in Privates)
                sb.AppendLine($" {item.Value}");

            return sb.ToString().TrimEnd();
        }
    }
}
