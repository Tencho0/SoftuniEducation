namespace T09.ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
        string IPerson.GetName()
        {
            return this.Name;
        }
    }
}
