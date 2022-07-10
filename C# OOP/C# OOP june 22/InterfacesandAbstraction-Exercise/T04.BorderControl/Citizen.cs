namespace T04.BorderControl
{
    public class Citizen : PartOfSociety
    {
        public Citizen(string name, int age, string id)
            : base(id)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
