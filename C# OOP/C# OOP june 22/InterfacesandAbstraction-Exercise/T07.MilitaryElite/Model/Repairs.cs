namespace T07.MilitaryElite.Model
{
    using Contracts;
    public class Repairs : IRepairs
    {
        public Repairs(string name, int workedHours)
        {
            Name = name;
            WorkedHours = workedHours;
        }

        public string Name { get; set; }
        public int WorkedHours { get; set; }

        public override string ToString()
        {
            return $"Part Name: {Name} Hours Worked: {WorkedHours}";
        }
    }
}
