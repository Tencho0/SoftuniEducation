namespace MilitaryElite
{
    public class Repairs : IRepairs
    {
        public Repairs(string name, int workingHours)
        {
            this.Name = name;
            this.WorkingHours = workingHours;
        }
        public string Name { get; set; }
        public int WorkingHours { get; set; }
        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.WorkingHours}";
        }
    }
}
