namespace T05.BirthdayCelebrations
{
    using Contracts;

    public class Citizen : PartOfSociety, IBirthdable
    {
        public Citizen(string name, int age, string id, string birthdate)
            : base(id)
        {
            Name = name;
            Age = age;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set; }
    }
}
